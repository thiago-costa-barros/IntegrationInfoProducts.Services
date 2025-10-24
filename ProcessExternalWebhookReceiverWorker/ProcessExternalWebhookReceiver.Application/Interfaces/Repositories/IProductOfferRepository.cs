using CommonSolution.Entities.CoreSchema;

namespace ProcessExternalWebhookReceiver.Application.Interfaces.Repositories
{
    public interface IProductOfferRepository
    {
        Task<ProductOffer> CreateProductOffer(ProductOffer productOffer);
        Task<ProductOffer?> GetProductOfferByIdentifierAndBusinessUnitId(string identifier, int businessUnitId);
    }
}
