using CommonSolution.Entities.Common;
using CommonSolution.Entities.CoreSchema;
using Microsoft.Extensions.Options;
using ProcessExternalWebhookReceiver.Application.Interfaces.DAOs;
using ProcessExternalWebhookReceiver.Application.Interfaces.Repositories;

namespace ProcessExternalWebhookReceiver.Infrastructure.Repositories
{
    public class CompanyBranchRepository : ICompanyBranchRepository
    {
        private readonly bool _useCache;
        private readonly ICompanyBranchDAO _companyBranchDAO;
        public CompanyBranchRepository(IOptions<AppSettings> appSettings, ICompanyBranchDAO companyBranchDAO)
        {
            _useCache = appSettings.Value.UseCache;
            _companyBranchDAO = companyBranchDAO;
        }
        public async Task<CompanyBranch> GetCompanyBranchByCompanyIdAndTaxNumber(int companyId, string taxNumber, CancellationToken cancellationToken = default)
        {
            if (_useCache)
            {
                // Implement caching logic here if needed
                // For example, check if the data is in cache and return it
                return null;
            }
            else
            {
                CompanyBranch company = await _companyBranchDAO.GetCompanyBranchByCompanyIdAndTaxNumber(companyId, taxNumber, cancellationToken);
                return company;
            }
        }
    }
}
