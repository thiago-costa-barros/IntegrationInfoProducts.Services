using ProcessExternalWebhookReceiver.Application.DTOs.Hotmart.Events;
using ProcessExternalWebhookReceiver.Application.DTOs.Hotmart.Events.Objects;

namespace ProcessExternalWebhookReceiver.Application.Interfaces.Services.Hotmart.Events
{
    public interface IHotmartEventPurchaseService
    {
        Task HandlePurchaseEventsAsync(HotmartEventPayload<HotmartPuchaseEventPayload> hotmartEventPayload, CancellationToken cancellationToken);
        //Task HandlePurchaseApprovedAsync(HotmartPuchaseEventPayload hotmartPuchaseEventPayload, CancellationToken cancellationToken);
        //Task HandlePurchaseCanceledAsync(HotmartPuchaseEventPayload hotmartPuchaseEventPayload, CancellationToken cancellationToken);
        //Task HandlePurchaseCompleteAsync(HotmartPuchaseEventPayload hotmartPuchaseEventPayload, CancellationToken cancellationToken);
        //Task HandlePurchaseBilletPrintedAsync(HotmartPuchaseEventPayload hotmartPuchaseEventPayload, CancellationToken cancellationToken);
        //Task HandlePurchaseProtestAsync(HotmartPuchaseEventPayload hotmartPuchaseEventPayload, CancellationToken cancellationToken);
        //Task HandlePurchaseRefundedAsync(HotmartPuchaseEventPayload hotmartPuchaseEventPayload, CancellationToken cancellationToken);
        //Task HandlePurchaseChargebackAsync(HotmartPuchaseEventPayload hotmartPuchaseEventPayload, CancellationToken cancellationToken);
        //Task HandlePurchaseExpiredAsync(HotmartPuchaseEventPayload hotmartPuchaseEventPayload, CancellationToken cancellationToken);
        //Task HandlePurchaseDelayedAsync(HotmartPuchaseEventPayload hotmartPuchaseEventPayload, CancellationToken cancellationToken);
    }
}
