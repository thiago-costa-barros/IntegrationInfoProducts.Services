using CommonSolution.Entities.Common.Enums;
using CommonSolution.Entities.IntegrationSchema;

namespace ProcessExternalWebhookReceiver.Application.Interfaces.Repositories
{
    public interface IExternalWebhookReceiverRepository
    {
        Task<List<ExternalWebhookReceiver>> GetExternalWebhookReceiverByStatusAsync(ExternalWebhookReceiverStatus externalWebhookReceiverStatus, CancellationToken cancellationToken = default);
    }
}
