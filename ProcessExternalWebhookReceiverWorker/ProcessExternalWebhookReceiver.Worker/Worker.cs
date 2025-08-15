using Microsoft.Extensions.Options;
using ProcessExternalWebhookReceiver.Application.Interfaces;
using ProcessExternalWebhookReceiver.Domain.Entities;

namespace ProcessExternalWebhookReceiverWorker
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IOptionsMonitor<ServiceExecution> _options;
        private readonly IServiceScopeFactory _scopeFactory;

        public Worker(ILogger<Worker> logger, IOptionsMonitor<ServiceExecution> options, IServiceScopeFactory scopeFactory)
        {
            _logger = logger;
            _options = options;
            _scopeFactory = scopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
            
            while (!stoppingToken.IsCancellationRequested)
            {
                var options = _options.CurrentValue;

                try
                {
                    var scope = _scopeFactory.CreateScope();
                    var exec = scope.ServiceProvider.GetRequiredService<IExecuteService>(); 
                    await exec.ExecuteAsync(options.BatchSize, stoppingToken);
                }
                catch (OperationCanceledException) when (stoppingToken.IsCancellationRequested) { }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "An error occurred while executing the worker.");
                }
                try
                {
                    await Task.Delay(options.IntervalMs, stoppingToken);
                }
                catch (OperationCanceledException) { }
            }
        }
    }
}
