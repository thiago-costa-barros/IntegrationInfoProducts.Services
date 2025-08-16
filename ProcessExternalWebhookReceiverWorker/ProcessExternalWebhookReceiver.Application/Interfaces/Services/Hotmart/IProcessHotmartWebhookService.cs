using CommonSolution.Entities.IntegrationSchema;

namespace ProcessExternalWebhookReceiver.Application.Interfaces.Services.Hotmart
{
    public interface IProcessHotmartWebhookService
    {
        /// <summary>
        /// Processes the Hotmart webhook by deserializing the payload and routing the event.
        /// </summary>
        /// <param name="externalWebhookReceiver">The external webhook receiver containing the payload.</param>
        /// <param name="cancellationToken">Cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task ProcessHotmartWebhook(ExternalWebhookReceiver externalWebhookReceiver, CancellationToken cancellationToken = default);
    }
}
