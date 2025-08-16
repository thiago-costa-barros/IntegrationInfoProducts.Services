using System.Text.Json.Serialization;

namespace ProcessExternalWebhookReceiver.Application.DTOs.Hotmart.Events.Objects.HotmartPurchaseEvent
{
    public class HotmartBuyerEventObject
    {
        [JsonPropertyName("email")]
        public string? Email { get; set; }
        [JsonPropertyName("name")]
        public string? Name { get; set; }
        [JsonPropertyName("first_name")]
        public string? FirstName { get; set; }
        [JsonPropertyName("last_name")]
        public string? LastName { get; set; }
        [JsonPropertyName("checkout_phone")]
        public string? CheckoutPhone { get; set; }
        [JsonPropertyName("checkout_phone_code")]
        public string? CheckoutPhoneCode { get; set; }
        [JsonPropertyName("document")]
        public string? Document { get; set; }
        [JsonPropertyName("document_type")]
        public string? DocumentType { get; set; }
        [JsonPropertyName("address")]
        public HotmartBuyerEventObjectAddress? Address { get; set; }
    }
    public class HotmartBuyerEventObjectAddress
    {
        [JsonPropertyName("country_iso")]
        public string? CountryIso { get; set; }
        [JsonPropertyName("country")]
        public string? Country { get; set; }
        [JsonPropertyName("zipcode")]
        public string? Zipcode { get; set; }
        [JsonPropertyName("state")]
        public string? State { get; set; }
        [JsonPropertyName("city")]
        public string? City { get; set; }
        [JsonPropertyName("neighborhood")]
        public string? Neighborhood { get; set; }
        [JsonPropertyName("street")]
        public string? Street { get; set; }
        [JsonPropertyName("complement")]
        public string? Complement { get; set; }
        [JsonPropertyName("number")]
        public string? Number { get; set; }
    }
}