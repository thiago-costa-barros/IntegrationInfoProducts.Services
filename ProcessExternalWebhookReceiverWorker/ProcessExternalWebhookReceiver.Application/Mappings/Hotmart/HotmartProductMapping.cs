using CommonSolution.Entities.Common;
using CommonSolution.Entities.Common.Enums;
using CommonSolution.Entities.CoreSchema;
using ProcessExternalWebhookReceiver.Application.DTOs.Hotmart.Events;
using ProcessExternalWebhookReceiver.Application.DTOs.Hotmart.Events.Objects;

namespace ProcessExternalWebhookReceiver.Application.Mappings.Hotmart
{
    public class HotmartProductMapping
    {
        public static Product HotmartProductMapToProduct(HotmartEventPayload<HotmartPuchaseEventPayload> hotmartEventPayload, int businessUnitId, DefaultUserService defaultUserService)
        {
            ProductType productType = ProductType.InfoProduct;
            bool isPhysicalProduct = hotmartEventPayload.Payload?.Data?.Product?.IsPhysicalProduct ?? false;
            if (isPhysicalProduct)
                productType = ProductType.PhysicalProduct;

            Product product = new Product
            {
                Name = hotmartEventPayload.Payload?.Data?.Product?.ProductName,
                Type = productType,
                Status = ProductStatus.Active,
                SourceType = ProductSourceType.Hotmart,
                BusinessUnitId = businessUnitId,
                Identifier = hotmartEventPayload.Payload?.Data?.Product?.ProductGuid.ToString(),
                ExternalIdentifier = hotmartEventPayload.Payload?.Data?.Product?.ProductId.ToString(),
                CreationUserId = defaultUserService.DefaultUserId,
                UpdateUserId = defaultUserService.DefaultUserId
            };
            return product;
        }
        public static ProductOffer HotmartProductMapToProductOffer(HotmartEventPayload<HotmartPuchaseEventPayload> hotmartEventPayload, int productId, int businessUnitId, DefaultUserService defaultUserService)
        {
            ProductOffer productOffer = new ProductOffer
            {
                Name = hotmartEventPayload.Payload?.Data?.Product?.ProductName,
                Description = hotmartEventPayload.Payload?.Data?.Purchase?.Offer?.Name,
                Externalidentifier = hotmartEventPayload.Payload?.Data?.Purchase?.Offer?.Code,
                Price = hotmartEventPayload.Payload?.Data?.Purchase?.OriginalOfferPrice?.Value ?? 0,
                ProductId = productId,
                BusinessUnitId = businessUnitId,
                CreationUserId = defaultUserService.DefaultUserId,
                UpdateUserId = defaultUserService.DefaultUserId
            };

            string? couponCode = hotmartEventPayload.Payload?.Data?.Purchase?.Offer?.CouponCode;
            if (!String.IsNullOrEmpty(couponCode))
                 = true;

            return productOffer;
        }
    }
}
