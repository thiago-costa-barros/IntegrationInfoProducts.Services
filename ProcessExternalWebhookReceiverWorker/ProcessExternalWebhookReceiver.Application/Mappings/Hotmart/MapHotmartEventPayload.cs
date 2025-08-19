using CommonSolution.Entities.IntegrationSchema;
using CommonSolution.Extensions;
using ProcessExternalWebhookReceiver.Application.DTOs.Hotmart;
using ProcessExternalWebhookReceiver.Application.DTOs.Hotmart.Events;
using ProcessExternalWebhookReceiver.Application.DTOs.Hotmart.Events.Objects;

namespace ProcessExternalWebhookReceiver.Application.Mappings.Hotmart
{
    public class MapHotmartEventPayload
    {
        public static Task<HotmartEventPayload<HotmartPuchaseEventPayload>> MapHotmartPurchaseEventPayload(ExternalWebhookReceiver externalWebhookReceiver,HotmartWebhookReceiverPayload hotmartWebhookReceiverPayload) 
        {
            HotmartEventPayload<HotmartPuchaseEventPayload> hotmartEventPayload = new HotmartEventPayload<HotmartPuchaseEventPayload>
            {
                ExternalWebhookReceiverId = externalWebhookReceiver.ExternalWebhookReceiverId,
                SourceType = externalWebhookReceiver.SourceType,
                Status = externalWebhookReceiver.Status,
                CompanyId = externalWebhookReceiver.CompanyId,
                ExternalIdentifier = externalWebhookReceiver.ExternalIdentifier,
                Payload = new HotmartEventPayloadData<HotmartPuchaseEventPayload>
                {
                    Id = hotmartWebhookReceiverPayload.Id,
                    CreationDate = hotmartWebhookReceiverPayload.CreationDate,
                    Event = hotmartWebhookReceiverPayload.Event,
                    Version = hotmartWebhookReceiverPayload.Version,
                    Data = hotmartWebhookReceiverPayload.Data.MapToObject<HotmartPuchaseEventPayload>()
                }
            };

            return Task.FromResult(hotmartEventPayload);
        }
    }
}
