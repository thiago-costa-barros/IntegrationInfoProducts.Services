using CommonSolution.Entities.IntegrationSchema;

namespace ProcessExternalWebhookReceiver.Application.Interfaces.Services
{
    public interface IProcessExternalWebhookReceiver
    {
        /// <summary>
        /// Processes the external webhook receiver based on its source type.
        /// </summary>
        /// <param name="externalWebhookReceiver">The external webhook receiver.</param>
        /// <param name="cancellationToken">Cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task ProcessExternalWebhookReceiver(ExternalWebhookReceiver externalWebhookReceiver, CancellationToken cancellationToken = default);
    }
}
