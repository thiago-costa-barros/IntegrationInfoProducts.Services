using CommonSolution.Entities.Common.Enums;
using CommonSolution.Entities.IntegrationSchema;
using Microsoft.Extensions.Logging;
using ProcessExternalWebhookReceiver.Application.Interfaces;
using ProcessExternalWebhookReceiver.Application.Interfaces.Repositories;

namespace ProcessExternalWebhookReceiver.Application.Worker
{
    public class ExecuteService: IExecuteService
    {
        private readonly ILogger<ExecuteService> _logger;
        private readonly IExternalWebhookReceiverRepository _externalWebhookReceiverRepository;
        public ExecuteService(ILogger<ExecuteService> logger, IExternalWebhookReceiverRepository externalWebhookReceiverRepository)
        {
            _logger = logger;
            _externalWebhookReceiverRepository = externalWebhookReceiverRepository;
        }
        public async Task ExecuteAsync(int batchSize, CancellationToken cancellationToken)
        {
            List<ExternalWebhookReceiver> externalWebhookReceivers = await _externalWebhookReceiverRepository.GetExternalWebhookReceiverByStatusAsync(ExternalWebhookReceiverStatus.Created, cancellationToken);
            _logger.LogInformation("Executing batch of size {BatchSize} at {Time}", batchSize, DateTimeOffset.Now);
            await Task.CompletedTask;
        }
    }
}