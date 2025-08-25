using CommonSolution.Entities.CoreSchema;
using ProcessExternalWebhookReceiver.Application.Interfaces.DAOs;
using ProcessExternalWebhookReceiver.Infrastructure.Data.Context;
using ProcessExternalWebhookReceiver.Infrastructure.Data.Context.Extensions.SqlServer;

namespace ProcessExternalWebhookReceiver.Infrastructure.Data.DAOs
{
    public class CompanyDAO : ICompanyDAO
    {
        private readonly ApplicationDbContext _context;
        public CompanyDAO(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Company> GetCompanyById(int companyId, CancellationToken cancellationToken = default)
        {
            var parameters = new (string, object?)[]
            {
                ("@paramId", companyId )
            };

            await using var command = _context.StoredProcedureCommand(
                "[CoreSchema].[GetCompanyById]",
                parameters);

            await using var reader = await command.ExecuteReaderAsync(cancellationToken);
            Company entity = await DataReaderMapper.MapToSingleAsync<Company>(reader);

            return entity;
        }
    }
}
