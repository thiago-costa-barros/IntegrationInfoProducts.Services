using ProcessExternalWebhookReceiver.Application.DTOs.Hotmart.Events;
using ProcessExternalWebhookReceiver.Application.DTOs.Hotmart.Events.Objects.HotmartPurchaseEvent;
using ProcessExternalWebhookReceiver.Application.Interfaces.Services.Hotmart;
using ProcessExternalWebhookReceiver.Domain.Entities.Enums;

namespace ProcessExternalWebhookReceiver.Application.Services.Hotmart
{
    public class HandlerHotmartWebhookEvents : IHandlerHotmartWebhookEvents
    {
        public Task HandlePurchaseEventsAsync(HotmartEventPayload<HotmartPurchaseEventObjectPayment> hotmartEventPayload, CancellationToken cancellationToken)
        {
            HotmartWebhookEventType eventType = Enum.Parse<HotmartWebhookEventType>(hotmartEventPayload.Payload!.Event!);

            switch (eventType)
            {
                case HotmartWebhookEventType.PURCHASE_APPROVED:
                    // Handle purchase approved event
                    return Task.CompletedTask;
                case HotmartWebhookEventType.PURCHASE_CANCELED:
                    // Handle purchase canceled event
                    return Task.CompletedTask;
                case HotmartWebhookEventType.PURCHASE_COMPLETE:
                    // Handle purchase complete event
                    return Task.CompletedTask;
                case HotmartWebhookEventType.PURCHASE_BILLET_PRINTED:
                    // Handle purchase billet printed event
                    return Task.CompletedTask;
                case HotmartWebhookEventType.PURCHASE_PROTEST:
                    // Handle purchase protest event
                    return Task.CompletedTask;
                case HotmartWebhookEventType.PURCHASE_REFUNDED:
                    // Handle purchase refunded event
                    return Task.CompletedTask;
                case HotmartWebhookEventType.PURCHASE_CHARGEBACK:
                    // Handle purchase chargeback event
                    return Task.CompletedTask;
                case HotmartWebhookEventType.PURCHASE_EXPIRED:
                    // Handle purchase expired event
                    return Task.CompletedTask;
                case HotmartWebhookEventType.PURCHASE_DELAYED:
                    // Handle purchase delayed event
                    return Task.CompletedTask;

            }
            return Task.CompletedTask;
        }
    }
}