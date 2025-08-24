using ProcessExternalWebhookReceiver.Application.DTOs.Hotmart.Events;
using ProcessExternalWebhookReceiver.Application.DTOs.Hotmart.Events.Objects;
using ProcessExternalWebhookReceiver.Application.DTOs.Hotmart.Events.Objects.HotmartPurchaseEvent;
using ProcessExternalWebhookReceiver.Application.Interfaces.Services.Hotmart;
using ProcessExternalWebhookReceiver.Application.Interfaces.Services.Hotmart.Events;
using ProcessExternalWebhookReceiver.Domain.Entities.Enums;

namespace ProcessExternalWebhookReceiver.Application.Services.Hotmart
{
    public class HandlerHotmartWebhookEventsService : IHandlerHotmartWebhookEvents
    {
        private readonly IHotmartEventPurchaseService _hotmartEventPurchaseService;
        public HandlerHotmartWebhookEventsService(IHotmartEventPurchaseService hotmartEventPurchaseService)
        {
            _hotmartEventPurchaseService = hotmartEventPurchaseService;
        }
        public async Task HandlePurchaseEventsAsync(HotmartEventPayload<HotmartPuchaseEventPayload> hotmartEventPayload, CancellationToken cancellationToken)
        {
            Enum.TryParse<HotmartWebhookEventType>(hotmartEventPayload.Payload!.Event!, out HotmartWebhookEventType eventType);

            switch (eventType)
            {
                case HotmartWebhookEventType.PURCHASE_APPROVED:
                    await _hotmartEventPurchaseService.HandlePurchaseEventsAsync(hotmartEventPayload, cancellationToken);
                    return;
                case HotmartWebhookEventType.PURCHASE_CANCELED:
                    // Handle purchase canceled event
                    return;
                case HotmartWebhookEventType.PURCHASE_COMPLETE:
                    // Handle purchase complete event
                    return;
                case HotmartWebhookEventType.PURCHASE_BILLET_PRINTED:
                    // Handle purchase billet printed event
                    return;
                case HotmartWebhookEventType.PURCHASE_PROTEST:
                    // Handle purchase protest event
                    return;
                case HotmartWebhookEventType.PURCHASE_REFUNDED:
                    // Handle purchase refunded event
                    return;
                case HotmartWebhookEventType.PURCHASE_CHARGEBACK:
                    // Handle purchase chargeback event
                    return;
                case HotmartWebhookEventType.PURCHASE_EXPIRED:
                    // Handle purchase expired event
                    return;
                case HotmartWebhookEventType.PURCHASE_DELAYED:
                    // Handle purchase delayed event
                    return;

            }
            return;
        }
    }
}