namespace ProcessExternalWebhookReceiver.Application.Worker.Interfaces
{
    public interface IExecuteService
    {
        Task ExecuteAsync(int batchSize, CancellationToken stoppingToken);
    }
}
