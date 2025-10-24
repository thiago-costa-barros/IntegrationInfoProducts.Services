using CommonSolution.Entities.CoreSchema;

namespace ProcessExternalWebhookReceiver.Application.Interfaces.Repositories
{
    public interface IProductRepository
    {
        Task<Product> CreateProduct(Product product);
        Task<Product?> GetProductByIdentifierAndBusinessUnitId(string externalIdentifier, int businessUnitId);
    }
}
