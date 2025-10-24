using CommonSolution.Entities.CoreSchema;

namespace ProcessExternalWebhookReceiver.Application.Interfaces.DAOs
{
    public interface IProductDAO
    {
        Task<Product> CreateProduct(Product product);
        Task<Product?> GetProductByIdentifierAndBusinessUnitId(string identifier, int businessUnitId);
    }
}
