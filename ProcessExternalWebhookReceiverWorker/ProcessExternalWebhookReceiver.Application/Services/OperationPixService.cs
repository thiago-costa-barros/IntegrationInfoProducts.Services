using CommonSolution.Entities.Common.Enums;
using CommonSolution.Entities.CoreSchema;
using ProcessExternalWebhookReceiver.Application.Interfaces.Repositories;
using ProcessExternalWebhookReceiver.Application.Interfaces.Services;

namespace ProcessExternalWebhookReceiver.Application.Services
{
    public class OperationPixService : IOperationPixService
    {
        private readonly IOperationPixRepository _operationPixRepository;
        public OperationPixService(IOperationPixRepository operationPixRepository)
        {
            _operationPixRepository = operationPixRepository;
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
