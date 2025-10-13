using CommonSolution.Entities.CoreSchema;

namespace ProcessExternalWebhookReceiver.Application.Interfaces.Services
{
    public interface IBusinessUnitService
    {
        Task<BusinessUnit> GetBusinessUnitById(int businessUnitId, CancellationToken cancellationToken = default);
    }
}
