using CommonSolution.Entities.CoreSchema;

namespace ProcessExternalWebhookReceiver.Application.Interfaces.Repositories
{
    public interface ICompanyRepository
    {
        Task<Company> GetCompanyById(int companyId, CancellationToken cancellationToken = default); 
    }
}
