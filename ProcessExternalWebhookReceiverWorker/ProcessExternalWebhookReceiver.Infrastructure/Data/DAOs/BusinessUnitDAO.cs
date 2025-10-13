using CommonSolution.CrossCutting.PostgresSQL;
using CommonSolution.CrossCutting.PostgresSQL.Extensions;
using CommonSolution.Entities.CoreSchema;
using ProcessExternalWebhookReceiver.Application.Interfaces.DAOs;
using System.ComponentModel.Design;

namespace ProcessExternalWebhookReceiver.Infrastructure.Data.DAOs
{
    public class BusinessUnitDAO : IBusinessUnitDAO
    {
        private readonly ApplicationDbContext _context;
        private const string SchemaName = "CoreSchema";
        public BusinessUnitDAO(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<BusinessUnit?> GetBusinessUnitById(int businessUnitId, CancellationToken cancellationToken = default)
        {
            var parameters = new (string, object?)[]
            {
                ("@paramId", businessUnitId )
            };

            await using var command = _context.FunctionCommand(
                SchemaName,
                "GetBusinessUnitById",
                parameters);

            await using var reader = await command.ExecuteReaderAsync(cancellationToken);
            BusinessUnit? entity = await DataReaderMapper.MapToSingleAsync<BusinessUnit>(reader);

            return entity;
        }
    }
}
