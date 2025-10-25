using CommonSolution.CrossCutting.PostgresSQL;
using CommonSolution.Entities.Common.Enums;
using CommonSolution.Entities.CoreSchema;
using ProcessExternalWebhookReceiver.Application.Interfaces.DAOs;

namespace ProcessExternalWebhookReceiver.Infrastructure.Data.DAOs
{
    public class OperationPixDAO : IOperationPixDAO
    {
        private readonly ApplicationDbContext _context;
        private const string SchemaName = "CoreSchema";
        public OperationPixDAO(ApplicationDbContext context)
        {
            _context = context;
        }
        public Task DeleteOperationPix(OperationPix operationPix)
        {
            throw new NotImplementedException();
        }

        public Task<OperationPix> GetOperationPixById(int operationPixId)
        {
            throw new NotImplementedException();
        }

        public Task<OperationPix> InsertOperationPix(OperationPix operationPix)
        {
            throw new NotImplementedException();
        }

        public Task<OperationPix> UpdateOperationPixByStatus(OperationPix operationPix, OperationStatus status)
        {
            throw new NotImplementedException();
        }
    }
}
