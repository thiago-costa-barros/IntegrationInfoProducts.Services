using System.Text.Json.Serialization;

namespace ProcessExternalWebhookReceiver.Application.DTOs.Hotmart.Events.Objects.HotmartPurchaseEvent
{
    public class HotmartSubscriptionEventObject
    {
        [JsonPropertyName("status")]
        public string? Status { get; set; }
        [JsonPropertyName("plan")]
        public HotmartSubscriptionEventObjectSubscriptionPlan? Plan { get; set; }
        [JsonPropertyName("subscriber")]
        public HotmartSubscriptionEventObjectSubscriber? Subscriber { get; set; }
    }
    public class HotmartSubscriptionEventObjectSubscriptionPlan
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }
        [JsonPropertyName("name")]
        public string? Name { get; set; }
    }
    public class HotmartSubscriptionEventObjectSubscriber
    {
        [JsonPropertyName("code")]
        public string? Code { get; set; }
    }
}
