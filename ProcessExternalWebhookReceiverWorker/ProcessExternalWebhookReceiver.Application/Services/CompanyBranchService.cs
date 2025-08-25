using CommonSolution.Entities.CoreSchema;
using ProcessExternalWebhookReceiver.Application.Interfaces.Repositories;
using ProcessExternalWebhookReceiver.Application.Interfaces.Services;

namespace ProcessExternalWebhookReceiver.Application.Services
{
    public class CompanyBranchService : ICompanyBranchService
    {
        private readonly ICompanyBranchRepository _companyBranchRepository;
        public CompanyBranchService(ICompanyBranchRepository companyBranchRepository)
        {
            _companyBranchRepository = companyBranchRepository;
        }
        public async Task<CompanyBranch> GetCompanyBranchByCompanyIdAndTaxNumber(int companyId, string taxNumber, CancellationToken cancellationToken = default)
        {
            CompanyBranch companyBranch = await _companyBranchRepository.GetCompanyBranchByCompanyIdAndTaxNumber(companyId, taxNumber, cancellationToken);
            if (companyBranch == null)
                throw new KeyNotFoundException($"CompanyBranch with CompanyId {companyId} and TaxNumber {taxNumber} not found.");
            return companyBranch;
        }
    }
}
