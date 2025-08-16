using CommonSolution.Entities.Common.Enums;
using CommonSolution.Entities.IntegrationSchema;

namespace ProcessExternalWebhookReceiver.Application.Interfaces.DAOs
{
    public interface IExternalWebhookReceiverDAO
    {
        Task<List<ExternalWebhookReceiver>> GetExternalWebhookReceiverByStatus(ExternalWebhookReceiverStatus externalWebhookReceiverStatus, CancellationToken cancellationToken = default);
        Task UpdateExternalWebhookReceiverStatusById(int externalWebhookReceiverId,ExternalWebhookReceiverStatus externalWebhookReceiverStatus, int userId, CancellationToken cancellationToken = default);
    }
}
