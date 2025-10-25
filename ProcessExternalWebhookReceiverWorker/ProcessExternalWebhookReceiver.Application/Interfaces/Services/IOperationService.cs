using CommonSolution.Entities.CoreSchema;

namespace ProcessExternalWebhookReceiver.Application.Interfaces.Services
{
    public interface IOperationService
    {
        Task<Operation?> GetOperationByIdentifierAndBusinessUnitId(string identifier, int businessUnitId);
        Task<Operation> InsertOperation(Operation operation);
    }
}
