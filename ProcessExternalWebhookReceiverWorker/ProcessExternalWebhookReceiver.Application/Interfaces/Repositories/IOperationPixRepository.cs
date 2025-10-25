using CommonSolution.Entities.Common.Enums;
using CommonSolution.Entities.CoreSchema;

namespace ProcessExternalWebhookReceiver.Application.Interfaces.Repositories
{
    public interface IOperationPixRepository
    {
        Task<OperationPix> InsertOperationPix(OperationPix operationPix);
        Task<OperationPix> UpdateOperationPixByStatus(OperationPix operationPix, OperationStatus status);
        Task DeleteOperationPix(OperationPix operationPix);
        Task<OperationPix> GetOperationPixById(int operationPixId);
    }
}
