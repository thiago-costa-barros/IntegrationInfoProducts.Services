using CommonSolution.Entities.IntegrationSchema;
using ProcessExternalWebhookReceiver.Application.DTOs.Hotmart;
using ProcessExternalWebhookReceiver.Application.Interfaces.Services.Hotmart;
using System.Text.Json;

namespace ProcessExternalWebhookReceiver.Application.Services.Hotmart
{
    public class ProcessHotmartWebhookService : IProcessHotmartWebhookService
    {
        private readonly IHotmartEventRouterService _hotmartEventRouterService;
        public ProcessHotmartWebhookService(IHotmartEventRouterService hotmartEventRouterService)
        {
            _hotmartEventRouterService = hotmartEventRouterService;
        }
        public async Task ProcessHotmartWebhook(ExternalWebhookReceiver externalWebhookReceiver, CancellationToken cancellationToken)
        {
            HotmartWebhookReceiverPayload? payload = JsonSerializer.Deserialize<HotmartWebhookReceiverPayload>(externalWebhookReceiver.Payload);
            if (payload == null)
            {
                throw new ArgumentNullException(nameof(payload), "Payload cannot be null");
            }

            await _hotmartEventRouterService.RouteAsync(externalWebhookReceiver, cancellationToken);

            await Task.CompletedTask;
        }
    }
}