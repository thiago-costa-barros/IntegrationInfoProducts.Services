using CommonSolution.Entities.Common;
using CommonSolution.Entities.CoreSchema;
using Microsoft.Extensions.Options;
using ProcessExternalWebhookReceiver.Application.Interfaces.DAOs;
using ProcessExternalWebhookReceiver.Application.Interfaces.Repositories;

namespace ProcessExternalWebhookReceiver.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly bool _useCache;
        private readonly IProductDAO _productDAO;
        public ProductRepository(IOptions<AppSettings> useCache,IProductDAO productDAO)
        {
            _useCache = useCache.Value.UseCache;
            _productDAO = productDAO;
        }
        public Task<Product> CreateProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public async Task<Product?> GetProductByIdentifierAndBusinessUnitId(string identifier, int businessUnitId)
        {
            if(_useCache)
            {
                throw new NotImplementedException();
            }
            else
            {
                Product? product = await _productDAO.GetProductByIdentifierAndBusinessUnitId(identifier, businessUnitId);
                return product;
            }
        }
    }
}
