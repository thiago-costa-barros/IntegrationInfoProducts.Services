using CommonSolution.CrossCutting.PostgresSQL;
using CommonSolution.CrossCutting.PostgresSQL.Extensions;
using CommonSolution.Entities.CoreSchema;
using ProcessExternalWebhookReceiver.Application.Interfaces.DAOs;

namespace ProcessExternalWebhookReceiver.Infrastructure.Data.DAOs
{
    public class ProductDAO : IProductDAO
    {
        private readonly ApplicationDbContext _context;
        private const string SchemaName = "CoreSchema";
        public ProductDAO(ApplicationDbContext context)
        {
            _context = context;
        }
        public Task<Product> CreateProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public async Task<Product?> GetProductByIdentifierAndBusinessUnitId(string identifier, int businessUnitId)
        {
            var parameters = new (string, object?)[]
            {
                ("@paramIdentifier", identifier ),
                ("@paramBusinessUnitId", businessUnitId )
            };
            await using var command = _context.FunctionCommand(
                SchemaName,
                "GetProductByIdentifierAndBusinessUnitId",
                parameters);

            await using var reader = await command.ExecuteReaderAsync();
            Product? entity = await DataReaderMapper.MapToSingleAsync<Product>(reader);

            return entity;
        }
    }
}
