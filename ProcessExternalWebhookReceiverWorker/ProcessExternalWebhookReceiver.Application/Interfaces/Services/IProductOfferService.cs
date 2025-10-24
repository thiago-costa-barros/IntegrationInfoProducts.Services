using CommonSolution.Entities.CoreSchema;

namespace ProcessExternalWebhookReceiver.Application.Interfaces.Services
{
    public interface IProductOfferService
    {
        Task<ProductOffer> GetOrCreateProductOffer(ProductOffer productOffer);
        Task<ProductOffer?> GetProductOfferByIdentifierAndBusinessUnitId(string externalIdentifier, int businessUnitId);
    }
}
