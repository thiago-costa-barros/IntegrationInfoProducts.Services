namespace ProcessExternalWebhookReceiver.Application.Interfaces
{
    public interface IExecuteService
    {
        Task ExecuteAsync(int batchSize, CancellationToken stoppingToken);
    }
}
