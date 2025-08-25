using CommonSolution.Entities.CoreSchema;

namespace ProcessExternalWebhookReceiver.Application.Interfaces.Services
{
    public interface ICompanyBranchService
    {
        Task<CompanyBranch> GetCompanyBranchByCompanyIdAndTaxNumber(int companyId, string taxNumber, CancellationToken cancellationToken = default);
    }
}
