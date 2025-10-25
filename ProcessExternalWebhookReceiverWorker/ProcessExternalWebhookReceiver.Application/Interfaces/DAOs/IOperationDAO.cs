using CommonSolution.Entities.CoreSchema;

namespace ProcessExternalWebhookReceiver.Application.Interfaces.DAOs
{
    public interface IOperationDAO
    {
        Task<Operation?> GetOperationByIdentifierAndBusinessUnitId(string identifier, int businessUnitId);
        Task<Operation> InsertOperation(Operation operation);
    }
}
