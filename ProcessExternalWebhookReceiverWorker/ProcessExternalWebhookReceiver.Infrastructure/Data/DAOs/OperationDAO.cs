using CommonSolution.CrossCutting.PostgresSQL;
using CommonSolution.CrossCutting.PostgresSQL.Extensions;
using CommonSolution.Entities.CoreSchema;
using ProcessExternalWebhookReceiver.Application.Interfaces.DAOs;
using System.Threading;

namespace ProcessExternalWebhookReceiver.Infrastructure.Data.DAOs
{
    public class OperationDAO : IOperationDAO
    {
        private readonly ApplicationDbContext _context;
        private readonly string SchemaName = "CoreSchema";
        public OperationDAO(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Operation?> GetOperationByIdentifierAndBusinessUnitId(string identifier, int businessUnitId)
        {
            var parameters = new (string, object?)[]
            {
                ("_paramIdentifier", identifier ),
                ("_paramBusinessUnitId", businessUnitId )
            };

            await using var command = _context.FunctionCommand(
                SchemaName,
                "GetOperationByIdentifierAndBusinessUnitId",
                parameters);

            await using var reader = await command.ExecuteReaderAsync();
            Operation? entity = await DataReaderMapper.MapToSingleAsync<Operation>(reader);

            return entity;
        }

        public async Task<Operation> InsertOperation(Operation operation)
        {
            _context.Add(operation);
            await _context.SaveChangesAsync();
            return operation;
        }
    }
}
