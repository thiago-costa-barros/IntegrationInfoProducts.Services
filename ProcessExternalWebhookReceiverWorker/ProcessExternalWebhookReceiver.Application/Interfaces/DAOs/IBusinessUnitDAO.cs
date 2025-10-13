using CommonSolution.Entities.CoreSchema;

namespace ProcessExternalWebhookReceiver.Application.Interfaces.DAOs
{
    public interface IBusinessUnitDAO
    {
        Task<BusinessUnit?> GetBusinessUnitById(int businessUnitId, CancellationToken cancellationToken = default);
    }
}
