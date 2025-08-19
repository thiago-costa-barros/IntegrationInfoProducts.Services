using CommonSolution.Entities.IntegrationSchema;
using ProcessExternalWebhookReceiver.Application.DTOs.Hotmart;

namespace ProcessExternalWebhookReceiver.Application.Interfaces.Services.Hotmart
{
    public interface IHotmartEventRouterService
    {
        Task RouteAsync(ExternalWebhookReceiver externalWebhookReceiver, CancellationToken cancellationToken);
    }
}
