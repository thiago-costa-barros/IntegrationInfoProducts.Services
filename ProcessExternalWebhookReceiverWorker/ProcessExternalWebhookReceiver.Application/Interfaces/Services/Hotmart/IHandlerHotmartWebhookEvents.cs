using CommonSolution.Entities.IntegrationSchema;
using ProcessExternalWebhookReceiver.Application.DTOs.Hotmart;
using ProcessExternalWebhookReceiver.Application.DTOs.Hotmart.Events;
using ProcessExternalWebhookReceiver.Application.DTOs.Hotmart.Events.Objects;
using ProcessExternalWebhookReceiver.Application.DTOs.Hotmart.Events.Objects.HotmartPurchaseEvent;

namespace ProcessExternalWebhookReceiver.Application.Interfaces.Services.Hotmart
{
    public interface IHandlerHotmartWebhookEvents
    {
        Task HandlePurchaseEventsAsync(HotmartEventPayload<HotmartPurchaseEventObjectPayment> hotmartEventPayload, CancellationToken cancellationToken);
        //Task HandlePurchaseApprovedAsync(HotmartPuchaseEventPayload hotmartPuchaseEventPayload, CancellationToken cancellationToken);
        //Task HandlePurchaseCanceledAsync(HotmartPuchaseEventPayload hotmartPuchaseEventPayload, CancellationToken cancellationToken);
        //Task HandlePurchaseCompleteAsync(HotmartPuchaseEventPayload hotmartPuchaseEventPayload, CancellationToken cancellationToken);
        //Task HandlePurchaseBilletPrintedAsync(HotmartPuchaseEventPayload hotmartPuchaseEventPayload, CancellationToken cancellationToken);
        //Task HandlePurchaseProtestAsync(HotmartPuchaseEventPayload hotmartPuchaseEventPayload, CancellationToken cancellationToken);
        //Task HandlePurchaseRefundedAsync(HotmartPuchaseEventPayload hotmartPuchaseEventPayload, CancellationToken cancellationToken);
        //Task HandlePurchaseChargebackAsync(HotmartPuchaseEventPayload hotmartPuchaseEventPayload, CancellationToken cancellationToken);
        //Task HandlePurchaseExpiredAsync(HotmartPuchaseEventPayload hotmartPuchaseEventPayload, CancellationToken cancellationToken);
        //Task HandlePurchaseDelayedAsync(HotmartPuchaseEventPayload hotmartPuchaseEventPayload, CancellationToken cancellationToken);
        //Task HandleSubscriptionCancellationAsync(HotmartPuchaseEventPayload hotmartPuchaseEventPayload, CancellationToken cancellationToken);
        //Task HandleSwitchPlanAsync(HotmartPuchaseEventPayload hotmartPuchaseEventPayload, CancellationToken cancellationToken);
        //Task HandlePurchaseOutOfShoppingCartAsync(HotmartPuchaseEventPayload hotmartPuchaseEventPayload, CancellationToken cancellationToken);
        //Task HandleUpdateSubscriptionChargeDateAsync(HotmartPuchaseEventPayload hotmartPuchaseEventPayload, CancellationToken cancellationToken);
        //Task HandleClubFirstAccessAsync(HotmartPuchaseEventPayload hotmartPuchaseEventPayload, CancellationToken cancellationToken);
        //Task HandleClubModuleCompletedAsync(HotmartPuchaseEventPayload hotmartPuchaseEventPayload, CancellationToken cancellationToken);
    }
}
