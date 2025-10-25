using CommonSolution.Entities.CoreSchema;
using ProcessExternalWebhookReceiver.Application.Interfaces.DAOs;
using ProcessExternalWebhookReceiver.Application.Interfaces.Repositories;

namespace ProcessExternalWebhookReceiver.Infrastructure.Repositories
{
    public class OperationRepository : IOperationRepository
    {
        private readonly IOperationDAO _operationDAO;
        public OperationRepository(IOperationDAO operationDAO)
        {
            _operationDAO = operationDAO;
        }
        public async Task<Operation?> GetOperationByIdentifierAndBusinessUnitId(string identifier, int businessUnitId)
        {
            Operation? operation = await _operationDAO.GetOperationByIdentifierAndBusinessUnitId(identifier, businessUnitId);
            return operation;
        }

        public async Task<Operation> InsertOperation(Operation operation)
        {
            await _operationDAO.InsertOperation(operation);
            return operation;
        }
    }
}
