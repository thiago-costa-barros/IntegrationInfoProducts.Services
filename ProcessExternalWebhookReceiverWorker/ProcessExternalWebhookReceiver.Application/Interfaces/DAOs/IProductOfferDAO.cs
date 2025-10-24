using CommonSolution.Entities.CoreSchema;

namespace ProcessExternalWebhookReceiver.Application.Interfaces.DAOs
{
    public interface IProductOfferDAO
    {
        Task<ProductOffer> CreateProductOffer(ProductOffer productOffer);
        Task<ProductOffer?> GetProductOfferIdByIdentifierAndBusinessUnitId(string identifier, int businessUnitId);
    }
}
