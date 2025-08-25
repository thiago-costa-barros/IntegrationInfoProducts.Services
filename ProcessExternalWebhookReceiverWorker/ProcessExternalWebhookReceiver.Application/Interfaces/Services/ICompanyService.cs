using CommonSolution.Entities.CoreSchema;

namespace ProcessExternalWebhookReceiver.Application.Interfaces.Services
{
    public interface ICompanyService
    {
        Task<Company> GetCompanyById(int companyId, CancellationToken cancellationToken = default);
    }
}
