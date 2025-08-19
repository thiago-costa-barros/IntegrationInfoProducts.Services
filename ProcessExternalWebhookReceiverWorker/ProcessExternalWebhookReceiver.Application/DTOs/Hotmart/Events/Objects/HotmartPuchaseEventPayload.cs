using ProcessExternalWebhookReceiver.Application.DTOs.Hotmart.Events.Objects.HotmartPurchaseEvent;
using System.Text.Json.Serialization;

namespace ProcessExternalWebhookReceiver.Application.DTOs.Hotmart.Events.Objects
{
    public class HotmartPuchaseEventPayload
    {
        [JsonPropertyName("product")]
        public HotmartProductEventObject? Product { get; set; }
        [JsonPropertyName("affilliates")]
        public List<HotmartAffilliatesEventObject>? Affilliates { get; set; }
        [JsonPropertyName("buyer")]
        public HotmartBuyerEventObject? Buyer { get; set; }
        [JsonPropertyName("producer")]
        public HotmartProducerEventObject? Producer { get; set; }
        [JsonPropertyName("commissions")]
        public List<HotmartCommissionsEventObject>? Commissions { get; set; }
        [JsonPropertyName("purchase")]
        public HotmartPurchaseEventObject? Purchase { get; set; }
        [JsonPropertyName("subscription")]
        public HotmartSubscriptionEventObject? Subscription { get; set; }
    }
}
