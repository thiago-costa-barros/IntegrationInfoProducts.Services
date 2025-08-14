using Microsoft.Extensions.Logging;
using ProcessExternalWebhookReceiver.Application.Worker.Interfaces;

namespace ProcessExternalWebhookReceiver.Application.Worker
{
    public class ExecuteService: IExecuteService
    {
        private readonly ILogger<ExecuteService> _logger;
        public ExecuteService(ILogger<ExecuteService> logger)
        {
            _logger = logger;
        }
        public async Task ExecuteAsync(int batchSize, CancellationToken stoppingToken)
        {
            // This method will contain the logic to execute the worker's tasks.
            // It will be called by the background service to perform its operations.
            _logger.LogInformation("Executing batch of size {BatchSize} at {Time}", batchSize, DateTimeOffset.Now);
            await Task.CompletedTask;
        }
    }
}