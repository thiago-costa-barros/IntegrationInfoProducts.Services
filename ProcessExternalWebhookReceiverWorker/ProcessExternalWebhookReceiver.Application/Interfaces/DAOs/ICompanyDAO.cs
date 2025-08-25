using CommonSolution.Entities.CoreSchema;

namespace ProcessExternalWebhookReceiver.Application.Interfaces.DAOs
{
    public interface ICompanyDAO
    {
        Task<Company> GetCompanyById(int companyId, CancellationToken cancellationToken = default);
    }
}
