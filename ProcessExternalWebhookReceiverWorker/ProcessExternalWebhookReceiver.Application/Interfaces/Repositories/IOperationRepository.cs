using CommonSolution.Entities.CoreSchema;

namespace ProcessExternalWebhookReceiver.Application.Interfaces.Repositories
{
    public interface IOperationRepository
    {
        Task<Operation?> GetOperationByIdentifierAndBusinessUnitId(string identifier, int businessUnitId);
        Task<Operation> InsertOperation(Operation operation);
    }
}
