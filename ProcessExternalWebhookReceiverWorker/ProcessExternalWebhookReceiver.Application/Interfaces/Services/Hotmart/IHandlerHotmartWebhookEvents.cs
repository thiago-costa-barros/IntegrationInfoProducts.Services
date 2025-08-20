using CommonSolution.Entities.IntegrationSchema;
using ProcessExternalWebhookReceiver.Application.DTOs.Hotmart;
using ProcessExternalWebhookReceiver.Application.DTOs.Hotmart.Events;
using ProcessExternalWebhookReceiver.Application.DTOs.Hotmart.Events.Objects;
using ProcessExternalWebhookReceiver.Application.DTOs.Hotmart.Events.Objects.HotmartPurchaseEvent;

namespace ProcessExternalWebhookReceiver.Application.Interfaces.Services.Hotmart
{
    public interface IHandlerHotmartWebhookEvents
    {
        Task HandlePurchaseEventsAsync(HotmartEventPayload<HotmartPuchaseEventPayload> hotmartEventPayload, CancellationToken cancellationToken);
        //Task HandleSubscriptionCancellationAsync(HotmartPuchaseEventPayload hotmartPuchaseEventPayload, CancellationToken cancellationToken);
        //Task HandleSwitchPlanAsync(HotmartPuchaseEventPayload hotmartPuchaseEventPayload, CancellationToken cancellationToken);
        //Task HandlePurchaseOutOfShoppingCartAsync(HotmartPuchaseEventPayload hotmartPuchaseEventPayload, CancellationToken cancellationToken);
        //Task HandleUpdateSubscriptionChargeDateAsync(HotmartPuchaseEventPayload hotmartPuchaseEventPayload, CancellationToken cancellationToken);
        //Task HandleClubFirstAccessAsync(HotmartPuchaseEventPayload hotmartPuchaseEventPayload, CancellationToken cancellationToken);
        //Task HandleClubModuleCompletedAsync(HotmartPuchaseEventPayload hotmartPuchaseEventPayload, CancellationToken cancellationToken);
    }
}
