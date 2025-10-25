using CommonSolution.Entities.Common.Enums;
using CommonSolution.Entities.CoreSchema;

namespace ProcessExternalWebhookReceiver.Application.Interfaces.Services
{
    public interface IOperationPixService
    {
        Task<OperationPix> InsertOperationPix(OperationPix operationPix);
        Task<OperationPix> UpdateOperationPixByStatus(OperationPix operationPix, OperationStatus status);
        Task DeleteOperationPix(OperationPix operationPix);
        Task<OperationPix> GetOperationPixById(int operationPixId);
    }
}
