using CommonSolution.Entities.CoreSchema;
using ProcessExternalWebhookReceiver.Application.Interfaces.Repositories;
using ProcessExternalWebhookReceiver.Application.Interfaces.Services;

namespace ProcessExternalWebhookReceiver.Application.Services
{
    public class ProductOfferService : IProductOfferService
    {
        private readonly IProductOfferRepository _productOfferRepository;
        public ProductOfferService(IProductOfferRepository productOfferRepository)
        {
            _productOfferRepository = productOfferRepository;
        }
        public async Task<ProductOffer> GetOrCreateProductOffer(ProductOffer productOffer)
        {
            ProductOffer? existingProductOffer = await _productOfferRepository.GetProductOfferByIdentifierAndBusinessUnitId(productOffer.ExternalIdentifier, productOffer.BusinessUnitId);
            if(existingProductOffer == null)
            {
                ProductOffer newProductOffer = await _productOfferRepository.CreateProductOffer(productOffer);
                return newProductOffer;
            }
            return existingProductOffer;
        }

        public Task<ProductOffer?> GetProductOfferByIdentifierAndBusinessUnitId(string externalIdentifier, int businessUnitId)
        {
            throw new NotImplementedException();
        }
    }
}
