using CommonSolution.Entities.IntegrationSchema;

namespace ProcessExternalWebhookReceiver.Application.Interfaces.Services.Hotmart
{
    public interface IHandlerHotmartWebhookEvents
    {
        Task HandlePurchaseEventAsync(ExternalWebhookReceiver externalWebhookReceiver, CancellationToken cancellationToken);
    }
}
