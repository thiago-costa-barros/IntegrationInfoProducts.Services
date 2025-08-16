using CommonSolution.Entities.Common.Enums;
using CommonSolution.Entities.IntegrationSchema;
using ProcessExternalWebhookReceiver.Application.Interfaces.Services;
using ProcessExternalWebhookReceiver.Application.Interfaces.Services.Hotmart;
using ProcessExternalWebhookReceiver.Application.Services.Hotmart;

namespace ProcessExternalWebhookReceiver.Application.Services
{
    public class ProcessExternalWebhookReceiverService: IProcessExternalWebhookReceiver
    {
        private readonly IProcessHotmartWebhookService _processHotmartWebhookService;
        public ProcessExternalWebhookReceiverService(IProcessHotmartWebhookService processHotmartWebhookService)
        {
            _processHotmartWebhookService = processHotmartWebhookService;
        }
        public async Task ProcessExternalWebhookReceiver(ExternalWebhookReceiver externalWebhookReceiver, CancellationToken cancellationToken)
        {
            switch (externalWebhookReceiver.SourceType)
            {
                case ExternalWebhookReceiverSourceType.Hotmart:
                    await _processHotmartWebhookService.ProcessHotmartWebhook(externalWebhookReceiver, cancellationToken);
                    break;
                case ExternalWebhookReceiverSourceType.Udemy:
                    // Process Udemy webhook
                    break;
                default:
                    throw new NotImplementedException($"SourceType {externalWebhookReceiver.SourceType} is not implemented.");
            }

            await Task.FromResult(ExternalWebhookReceiverStatus.Proccessed); // Simulate processing result
        }
    }
}