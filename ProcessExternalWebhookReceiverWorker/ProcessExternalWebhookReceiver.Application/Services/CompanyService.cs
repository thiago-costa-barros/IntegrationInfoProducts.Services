using CommonSolution.Entities.CoreSchema;
using ProcessExternalWebhookReceiver.Application.Interfaces.Repositories;
using ProcessExternalWebhookReceiver.Application.Interfaces.Services;

namespace ProcessExternalWebhookReceiver.Application.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        public CompanyService(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }
        public async Task<Company> GetCompanyById(int companyId, CancellationToken cancellationToken = default)
        {
            Company company = await _companyRepository.GetCompanyById(companyId);

            if (company is null)
                throw new KeyNotFoundException($"Company with ID {companyId} not found.");
            return company;
        }
    }
}
