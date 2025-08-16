using CommonSolution.Entities.IntegrationSchema;
using CommonSolution.Extensions;
using CommonSolution.Helpers;
using ProcessExternalWebhookReceiver.Application.DTOs.Hotmart;
using ProcessExternalWebhookReceiver.Application.DTOs.Hotmart.Events;
using ProcessExternalWebhookReceiver.Application.Interfaces.Services.Hotmart;
using ProcessExternalWebhookReceiver.Domain.Entities.Enums;
using System.Text.Json;

namespace ProcessExternalWebhookReceiver.Application.Services.Hotmart
{
    public class ProcessHotmartWebhookService : IProcessHotmartWebhookService
    {
        public async Task ProcessHotmartWebhook(ExternalWebhookReceiver externalWebhookReceiver, CancellationToken cancellationToken)
        {
            HotmartWebhookReceiverPayload? payload = JsonSerializer.Deserialize<HotmartWebhookReceiverPayload>(externalWebhookReceiver.Payload);
            if (payload == null)
            {
                throw new ArgumentNullException(nameof(payload), "Payload cannot be null");
            }

            payload = await HotmartEventRouter(externalWebhookReceiver, payload);

            await Task.CompletedTask;
        }
        private static Task<HotmartWebhookReceiverPayload> HotmartEventRouter(ExternalWebhookReceiver externalWebhookReceiver, HotmartWebhookReceiverPayload payload)
        {
            EnumHelper.TryParseEnum(payload.Event, out HotmartWebhookEventType eventType);

            switch (eventType)
            {
                case HotmartWebhookEventType.PURCHASE_APPROVED:
                case HotmartWebhookEventType.PURCHASE_CANCELED:
                case HotmartWebhookEventType.PURCHASE_COMPLETE:
                case HotmartWebhookEventType.PURCHASE_BILLET_PRINTED:
                case HotmartWebhookEventType.PURCHASE_PROTEST:
                case HotmartWebhookEventType.PURCHASE_REFUNDED:
                case HotmartWebhookEventType.PURCHASE_CHARGEBACK:
                case HotmartWebhookEventType.PURCHASE_EXPIRED:
                case HotmartWebhookEventType.PURCHASE_DELAYED:
                    payload.Data.MapToObject<HotmartPuchaseEventPayload>();
                    break;
                case HotmartWebhookEventType.SUBSCRIPTION_CANCELLATION:
                    // Handle subscription created event
                    break;
                case HotmartWebhookEventType.SWITCH_PLAN:
                    // Handle switch plan event
                    break;
                case HotmartWebhookEventType.PURCHASE_OUT_OF_SHOPPING_CART:
                    // Handle purchase out of shopping cart event
                    break;
                case HotmartWebhookEventType.UPDATE_SUBSCRIPTION_CHARGE_DATE:
                    // Handle update subscription charge date event
                    break;
                case HotmartWebhookEventType.CLUB_FIRST_ACCESS:
                    // Handle club first access event
                    break;
                case HotmartWebhookEventType.CLUB_MODULE_COMPLETED:
                    // Handle club completed module events
                    break;
                default:
                    throw new NotImplementedException($"Event {eventType} is not implemented.");
            }

            return Task.FromResult(payload);
        }
    }
}