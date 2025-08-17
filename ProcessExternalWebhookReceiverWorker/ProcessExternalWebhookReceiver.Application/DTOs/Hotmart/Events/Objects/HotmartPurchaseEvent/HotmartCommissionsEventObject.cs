using System.Text.Json.Serialization;

namespace ProcessExternalWebhookReceiver.Application.DTOs.Hotmart.Events.Objects.HotmartPurchaseEvent
{
    public class HotmartCommissionsEventObject
    {
        [JsonPropertyName("value")]
        public decimal Value { get; set; }
        [JsonPropertyName("currency_value")]
        public string? CurrencyValue { get; set; }
        [JsonPropertyName("source")]
        public string? Source { get; set; }
        [JsonPropertyName("currency_conversion")]
        public HotmartCommissionsEventObjectCurrencyConversion? CurrencyConversion { get; set; }
    }
    public class HotmartCommissionsEventObjectCurrencyConversion
    {
        [JsonPropertyName("converted_value")]
        public decimal ConvertedValue { get; set; }
        [JsonPropertyName("converted_to_currency")]
        public decimal ConvertedToCurrency { get; set; }
        [JsonPropertyName("converted_rate")]
        public decimal ConvertedRate { get; set; }
    }
}
