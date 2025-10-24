using CommonSolution.Entities.CoreSchema;

namespace ProcessExternalWebhookReceiver.Application.Interfaces.Services
{
    public interface IProductService
    {
        Task<Product> CreateProduct(Product product);
        Task<Product> GetOrCreateProduct(Product product);
        Task<Product?> GetProductByIdentifierAndBusinessUnitId(string identifier, int businessUnitId);
    }
}
