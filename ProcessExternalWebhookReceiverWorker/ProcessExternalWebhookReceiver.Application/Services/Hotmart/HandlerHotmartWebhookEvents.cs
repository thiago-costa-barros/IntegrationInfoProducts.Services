using CommonSolution.Entities.IntegrationSchema;
using ProcessExternalWebhookReceiver.Application.Interfaces.Services.Hotmart;

namespace ProcessExternalWebhookReceiver.Application.Services.Hotmart
{
    public class HandlerHotmartWebhookEvents : IHandlerHotmartWebhookEvents
    {
        public Task HandlePurchaseEventAsync(ExternalWebhookReceiver externalWebhookReceiver, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
