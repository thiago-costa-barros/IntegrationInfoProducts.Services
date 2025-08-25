using CommonSolution.Entities.CoreSchema;
using ProcessExternalWebhookReceiver.Application.Interfaces.DAOs;
using ProcessExternalWebhookReceiver.Infrastructure.Data.Context;
using ProcessExternalWebhookReceiver.Infrastructure.Data.Context.Extensions.SqlServer;

namespace ProcessExternalWebhookReceiver.Infrastructure.Data.DAOs
{
    public class CompanyBranchDAO : ICompanyBranchDAO
    {
        private readonly ApplicationDbContext _context;
        public CompanyBranchDAO(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<CompanyBranch> GetCompanyBranchByCompanyIdAndTaxNumber(int companyId, string taxNumber, CancellationToken cancellationToken = default)
        {
            var parameters = new (string, object?)[]
            {
                ("@paramCompanyId", companyId ),
                ("@paramTaxNumber", taxNumber )
            };

            await using var command = _context.StoredProcedureCommand(
                "[CoreSchema].[GetCompanyBranchByCompanyIdAndTaxNumber]",
                parameters);

            await using var reader = await command.ExecuteReaderAsync(cancellationToken);
            CompanyBranch entity = await DataReaderMapper.MapToSingleAsync<CompanyBranch>(reader);

            return entity;
        }
    }
}
