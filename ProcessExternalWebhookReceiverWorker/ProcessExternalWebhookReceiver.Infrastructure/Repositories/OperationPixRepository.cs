using CommonSolution.Entities.Common.Enums;
using CommonSolution.Entities.CoreSchema;
using ProcessExternalWebhookReceiver.Application.Interfaces.DAOs;
using ProcessExternalWebhookReceiver.Application.Interfaces.Repositories;

namespace ProcessExternalWebhookReceiver.Infrastructure.Repositories
{
    public class OperationPixRepository : IOperationPixRepository
    {
        private readonly IOperationPixDAO _operationPixDAO;
        public OperationPixRepository(IOperationPixDAO operationPixDAO)
        {
            _operationPixDAO = operationPixDAO;
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
