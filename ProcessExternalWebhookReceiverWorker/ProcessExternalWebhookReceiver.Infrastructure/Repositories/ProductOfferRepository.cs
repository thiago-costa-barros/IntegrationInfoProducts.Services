using CommonSolution.Entities.Common;
using CommonSolution.Entities.CoreSchema;
using Microsoft.Extensions.Options;
using ProcessExternalWebhookReceiver.Application.Interfaces.DAOs;
using ProcessExternalWebhookReceiver.Application.Interfaces.Repositories;

namespace ProcessExternalWebhookReceiver.Infrastructure.Repositories
{
    public class ProductOfferRepository : IProductOfferRepository
    {
        private readonly bool _useCache;
        private readonly IProductOfferDAO _productOfferDAO;
        public ProductOfferRepository(IOptions<AppSettings> appSettings, IProductOfferDAO productOfferDAO)
        {
            _useCache = appSettings.Value.UseCache;
            _productOfferDAO = productOfferDAO;
        }
        public Task<ProductOffer> CreateProductOffer(ProductOffer productOffer)
        {
            throw new NotImplementedException();
        }

        public async Task<ProductOffer?> GetProductOfferByIdentifierAndBusinessUnitId(string identifier, int businessUnitId)
        {
            if(_useCache)
            {
                throw new NotImplementedException();
            }
            else
            {
                ProductOffer? productOffer = await _productOfferDAO.GetProductOfferIdByIdentifierAndBusinessUnitId(identifier, businessUnitId);
                return productOffer;
            }
        }
    }
}
