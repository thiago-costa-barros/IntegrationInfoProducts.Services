using CommonSolution.Entities.CoreSchema;
using CommonSolution.CrossCutting.PostgresSQL;
using CommonSolution.CrossCutting.PostgresSQL.Extensions;
using ProcessExternalWebhookReceiver.Application.Interfaces.DAOs;

namespace ProcessExternalWebhookReceiver.Infrastructure.Data.DAOs
{
    public class CompanyDAO : ICompanyDAO
    {
        private readonly ApplicationDbContext _context;
        private const string SchemaName = "CoreSchema";
        public CompanyDAO(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Company?> GetCompanyById(int companyId, CancellationToken cancellationToken = default)
        {
            var parameters = new (string, object?)[]
            {
                ("@paramId", companyId )
            };

            await using var command = _context.FunctionCommand(
                SchemaName,
                "GetCompanyById",
                parameters);

            await using var reader = await command.ExecuteReaderAsync(cancellationToken);
            Company? entity = await DataReaderMapper.MapToSingleAsync<Company>(reader);

            return entity;
        }
    }
}
