using CommonSolution.Entities.IntegrationSchema;
using CommonSolution.Extensions;
using ProcessExternalWebhookReceiver.Application.DTOs.Hotmart;
using ProcessExternalWebhookReceiver.Application.DTOs.Hotmart.Events;
using ProcessExternalWebhookReceiver.Application.DTOs.Hotmart.Events.Objects.HotmartPurchaseEvent;

namespace ProcessExternalWebhookReceiver.Application.Mappings.Hotmart
{
    public class MapHotmartEventPayload
    {
        public static Task<HotmartEventPayload<HotmartPurchaseEventObjectPayment>> MapHotmartPurchaseEventPayload(ExternalWebhookReceiver externalWebhookReceiver,HotmartWebhookReceiverPayload hotmartWebhookReceiverPayload) 
        {
            HotmartEventPayload<HotmartPurchaseEventObjectPayment> hotmartEventPayload = new HotmartEventPayload<HotmartPurchaseEventObjectPayment>
            {
                ExternalWebhookReceiverId = externalWebhookReceiver.ExternalWebhookReceiverId,
                SourceType = externalWebhookReceiver.SourceType,
                Status = externalWebhookReceiver.Status,
                CompanyId = externalWebhookReceiver.CompanyId,
                ExternalIdentifier = externalWebhookReceiver.ExternalIdentifier,
                Payload = new HotmartEventPayloadData<HotmartPurchaseEventObjectPayment>
                {
                    Id = hotmartWebhookReceiverPayload.Id,
                    CreationDate = hotmartWebhookReceiverPayload.CreationDate,
                    Event = hotmartWebhookReceiverPayload.Event,
                    Version = hotmartWebhookReceiverPayload.Version,
                    Data = hotmartWebhookReceiverPayload.Data.MapToObject<HotmartPurchaseEventObjectPayment>()
                }
            };

            return Task.FromResult(hotmartEventPayload);
        }
    }
}
