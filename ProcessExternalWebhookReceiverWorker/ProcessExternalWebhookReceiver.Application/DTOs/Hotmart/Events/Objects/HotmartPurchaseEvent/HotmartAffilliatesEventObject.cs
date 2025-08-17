using System.Text.Json.Serialization;

namespace ProcessExternalWebhookReceiver.Application.DTOs.Hotmart.Events.Objects.HotmartPurchaseEvent
{
    public class HotmartAffilliatesEventObject
    {
        [JsonPropertyName("affiliate_code")]
        public string? AffiliateCode { get; set; }
        [JsonPropertyName("name")]
        public string? Name { get; set; }
    }
}
