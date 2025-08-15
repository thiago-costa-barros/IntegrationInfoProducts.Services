using CommonSolution.Entities.Common.Enums;
using CommonSolution.Entities.IntegrationSchema;

namespace ProcessExternalWebhookReceiver.Application.Interfaces.DAOs
{
    public interface IExternalWebhookReceiverDAO
    {
        Task<List<ExternalWebhookReceiver>> GetExternalWebhookReceiverByStatus(ExternalWebhookReceiverStatus externalWebhookReceiverStatus);
    }
}
