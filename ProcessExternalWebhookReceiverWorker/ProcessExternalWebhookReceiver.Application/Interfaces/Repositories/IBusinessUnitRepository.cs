using CommonSolution.Entities.CoreSchema;

namespace ProcessExternalWebhookReceiver.Application.Interfaces.Repositories
{
    public interface IBusinessUnitRepository
    {
        Task<BusinessUnit?> GetBusinessUnitById(int businessUnitId, CancellationToken cancellationToken = default)?
    }
}
