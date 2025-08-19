using CommonSolution.Entities.IntegrationSchema;
using CommonSolution.Extensions;
using CommonSolution.Helpers;
using ProcessExternalWebhookReceiver.Application.DTOs.Hotmart;
using ProcessExternalWebhookReceiver.Application.DTOs.Hotmart.Events;
using ProcessExternalWebhookReceiver.Application.DTOs.Hotmart.Events.Objects;
using ProcessExternalWebhookReceiver.Application.DTOs.Hotmart.Events.Objects.HotmartPurchaseEvent;
using ProcessExternalWebhookReceiver.Application.Interfaces.Services.Hotmart;
using ProcessExternalWebhookReceiver.Application.Mappings.Hotmart;
using ProcessExternalWebhookReceiver.Domain.Entities.Enums;
using System.Text.Json;

namespace ProcessExternalWebhookReceiver.Application.Services.Hotmart
{
    public class HotmartEventRouterService : IHotmartEventRouterService
    {
        private readonly IHandlerHotmartWebhookEvents _handlerHotmartPurchaseEvent;
        public HotmartEventRouterService(IHandlerHotmartWebhookEvents handlerHotmartPurchaseEvent)
        {
            _handlerHotmartPurchaseEvent = handlerHotmartPurchaseEvent;
        }
        public async Task RouteAsync(ExternalWebhookReceiver externalWebhookReceiver, CancellationToken cancellationToken)
        {
            HotmartWebhookReceiverPayload payload = JsonSerializer.Deserialize<HotmartWebhookReceiverPayload>(externalWebhookReceiver.Payload);
            
            if (!EnumHelper.TryParseEnum(payload.Event, out HotmartWebhookEventType eventType))
                throw new InvalidOperationException($"Evento inválido: {payload.Event}");

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
                    HotmartEventPayload<HotmartPurchaseEventObjectPayment> hotmartEventPayload = await MapHotmartEventPayload.MapHotmartPurchaseEventPayload(externalWebhookReceiver,payload);
                    await _handlerHotmartPurchaseEvent.HandlePurchaseEventsAsync(hotmartEventPayload, cancellationToken);
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

            await Task.CompletedTask;
        }
    }
}
