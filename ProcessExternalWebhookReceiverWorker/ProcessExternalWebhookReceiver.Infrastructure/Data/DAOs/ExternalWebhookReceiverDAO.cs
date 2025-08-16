using CommonSolution.Entities.Common.Enums;
using CommonSolution.Entities.IntegrationSchema;
using ProcessExternalWebhookReceiver.Application.Interfaces.DAOs;
using ProcessExternalWebhookReceiver.Infrastructure.Data.Context;
using ProcessExternalWebhookReceiver.Infrastructure.Data.Context.Extensions.SqlServer;

namespace ProcessExternalWebhookReceiver.Infrastructure.Data.DAOs
{
    public class ExternalWebhookReceiverDAO : IExternalWebhookReceiverDAO
    {
        private readonly ApplicationDbContext _context;
        public ExternalWebhookReceiverDAO(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<ExternalWebhookReceiver>> GetExternalWebhookReceiverByStatus(ExternalWebhookReceiverStatus externalWebhookReceiverStatus, CancellationToken cancellationToken = default)
        {
            var parameters = new (string, object?)[]
            {
                ("@paramStatus", externalWebhookReceiverStatus )
            };

            await using var command = _context.StoredProcedureCommand(
                "[IntegrationSchema].[GetExternalWebhookReceiverByStatus]", 
                parameters);

            await using var reader = await command.ExecuteReaderAsync(cancellationToken);
            List<ExternalWebhookReceiver> entity = await DataReaderMapper.MapToListAsync<ExternalWebhookReceiver>(reader);
            
            return entity;
        }

        public async Task UpdateExternalWebhookReceiverStatusById(int externalWebhookReceiverId, ExternalWebhookReceiverStatus externalWebhookReceiverStatus, int userId, CancellationToken cancellationToken = default)
        {
            var parameters = new (string, object?)[]
            {
                ("@paramExternalWebhookReceiverId", externalWebhookReceiverId),
                ("@paramStatus", externalWebhookReceiverStatus),
                ("@paramUserId", userId)
            };

            await using var command = _context.StoredProcedureCommand(
                "[IntegrationSchema].[UpdateExternalWebhookReceiverStatusById]", 
                parameters);

            await using var reader = await command.ExecuteReaderAsync(cancellationToken);
        }
    }
}
