using System.Text.Json.Serialization;

namespace ProcessExternalWebhookReceiver.Application.DTOs.Hotmart.Events.Objects.HotmartPurchaseEvent
{
    public class HotmartProducerEventObject
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }
        [JsonPropertyName("document")]
        public string? Document { get; set; }
        [JsonPropertyName("legal_nature")]
        public string? LegalNature { get; set; }
    }
}
