using CommonSolution.CrossCutting.PostgresSQL;
using CommonSolution.CrossCutting.PostgresSQL.Extensions;
using CommonSolution.Entities.CoreSchema;
using ProcessExternalWebhookReceiver.Application.Interfaces.DAOs;

namespace ProcessExternalWebhookReceiver.Infrastructure.Data.DAOs
{
    public class ProductOfferDAO : IProductOfferDAO
    {
        private readonly ApplicationDbContext _context;
        private const string SchemaName = "CoreSchema";
        public ProductOfferDAO(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ProductOffer> CreateProductOffer(ProductOffer productOffer)
        {
            _context.Add(productOffer);
            await _context.SaveChangesAsync();

            return productOffer;
        }

        public async Task<ProductOffer?> GetProductOfferIdByIdentifierAndBusinessUnitId(string identifier, int businessUnitId)
        {
            var parameters = new (string, object?)[]
            {
                ("@paramExternalIdentifier", identifier),
                ("@paramBusinessUnitId", businessUnitId) 
            };
            await using var command = _context.FunctionCommand(
                SchemaName,
                "GetProductOfferByIdentifierAndBusinessUnitId",
                parameters);

            await using var reader = await command.ExecuteReaderAsync();
            ProductOffer? result = await DataReaderMapper.MapToSingleAsync<ProductOffer>(reader);

            return result;
        }
    }
}
