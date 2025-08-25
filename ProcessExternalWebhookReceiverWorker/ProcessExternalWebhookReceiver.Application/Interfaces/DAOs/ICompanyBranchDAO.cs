using CommonSolution.Entities.CoreSchema;

namespace ProcessExternalWebhookReceiver.Application.Interfaces.DAOs
{
    public interface ICompanyBranchDAO
    {
        Task<CompanyBranch> GetCompanyBranchByCompanyIdAndTaxNumber(int companyId, string taxNumber, CancellationToken cancellationToken = default);
    }
}
