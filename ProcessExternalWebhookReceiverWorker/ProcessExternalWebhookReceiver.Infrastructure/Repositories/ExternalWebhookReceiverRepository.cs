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
        public async Task<List<ExternalWebhookReceiver>> GetExternalWebhookReceiverByStatusAsync(ExternalWebhookReceiverStatus externalWebhookReceiverStatus, CancellationToken cancellationToken = default)
        {
            return await _externalWebhookReceiverDAO.GetExternalWebhookReceiverByStatus(externalWebhookReceiverStatus, cancellationToken);
        }

        public async Task UpdateExternalWebhookReceiverStatusById(int externalWebhookReceiverId, ExternalWebhookReceiverStatus externalWebhookReceiverStatus, int userId, CancellationToken cancellationToken = default)
        {
            await _externalWebhookReceiverDAO.UpdateExternalWebhookReceiverStatusById(externalWebhookReceiverId, externalWebhookReceiverStatus, userId, cancellationToken);
        }
    }
}
