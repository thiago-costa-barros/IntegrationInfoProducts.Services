using CommonSolution.Entities.Common;
using CommonSolution.Entities.CoreSchema;
using Microsoft.Extensions.Options;
using ProcessExternalWebhookReceiver.Application.Interfaces.DAOs;
using ProcessExternalWebhookReceiver.Application.Interfaces.Repositories;

namespace ProcessExternalWebhookReceiver.Infrastructure.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly bool _useCache;
        private readonly ICompanyDAO _companyDAO;
        public CompanyRepository(IOptions<AppSettings> appSettings, ICompanyDAO companyDAO)
        {
            _useCache = appSettings.Value.UseCache;
            _companyDAO = companyDAO;
        }
        public async Task<Company> GetCompanyById(int companyId, CancellationToken cancellationToken = default)
        {
            if (_useCache)
            {
                // Try to get from cache
                // For now, return null if not implemented
                return null;
            }
            else
            {
                Company company = await _companyDAO.GetCompanyById(companyId);
                return company;
            }
        }
    }
}
