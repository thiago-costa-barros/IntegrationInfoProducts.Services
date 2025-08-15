using CommonSolution.Entities.Common.Enums;
using CommonSolution.Entities.IntegrationSchema;
using ProcessExternalWebhookReceiver.Application.Interfaces.DAOs;
using ProcessExternalWebhookReceiver.Application.Interfaces.Repositories;

namespace ProcessExternalWebhookReceiver.Infrastructure.Repositories
{
    public class ExternalWebhookReceiverRepository : IExternalWebhookReceiverRepository
    {
        private readonly IExternalWebhookReceiverDAO _externalWebhookReceiverDAO;
        public ExternalWebhookReceiverRepository(IExternalWebhookReceiverDAO externalWebhookReceiverDAO)
        {
            _externalWebhookReceiverDAO = externalWebhookReceiverDAO;
        }
        public async Task<List<ExternalWebhookReceiver>> GetExternalWebhookReceiverByStatusAsync(ExternalWebhookReceiverStatus externalWebhookReceiverStatus)
        {
            return await _externalWebhookReceiverDAO.GetExternalWebhookReceiverByStatus(externalWebhookReceiverStatus);
        }
    }
}
