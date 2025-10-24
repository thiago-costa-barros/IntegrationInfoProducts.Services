using CommonSolution.Entities.CoreSchema;
using ProcessExternalWebhookReceiver.Application.Interfaces.Repositories;
using ProcessExternalWebhookReceiver.Application.Interfaces.Services;

namespace ProcessExternalWebhookReceiver.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public Task<Product> CreateProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public async Task<Product> GetOrCreateProduct(Product product)
        {
            Product? existingProduct = await _productRepository.GetProductByIdentifierAndBusinessUnitId(product.Identifier, product.BusinessUnitId);
            if (existingProduct == null)
            {
                Product newProduct = await _productRepository.CreateProduct(product);
                return newProduct;
            }    
            return existingProduct;
        }

        public Task<Product?> GetProductByIdentifierAndBusinessUnitId(string identifier, int businessUnitId)
        {
            throw new NotImplementedException();
        }
    }
}
