using CommonSolution.Entities.CoreSchema;
using ProcessExternalWebhookReceiver.Application.Interfaces.Repositories;
using ProcessExternalWebhookReceiver.Application.Interfaces.Services;

namespace ProcessExternalWebhookReceiver.Application.Services
{
    public class OperationService : IOperationService
    {

        private readonly IOperationRepository _operationRepository;
        public OperationService(IOperationRepository operationRepository)
        {
            _operationRepository = operationRepository;
        }
        public async Task<Operation?> GetOperationByIdentifierAndBusinessUnitId(string identifier, int businessUnitId)
        {
            Operation? operation = await _operationRepository.GetOperationByIdentifierAndBusinessUnitId(identifier, businessUnitId);
            return operation;
        }

        public async Task<Operation> InsertOperation(Operation operation)
        {
            await _operationRepository.InsertOperation(operation);
            return operation;
        }
    }
}
