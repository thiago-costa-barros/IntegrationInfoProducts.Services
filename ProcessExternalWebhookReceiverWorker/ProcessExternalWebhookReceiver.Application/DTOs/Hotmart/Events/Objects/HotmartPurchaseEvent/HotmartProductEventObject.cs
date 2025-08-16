using System.Text.Json.Serialization;

namespace ProcessExternalWebhookReceiver.Application.DTOs.Hotmart.Events.Objects.HotmartPurchaseEvent
{
    public class HotmartProductEventObject
    {
        [JsonPropertyName("id")]
        public int ProductId { get; set; }
        [JsonPropertyName("ucode")]
        public Guid? ProductGuid { get; set; }
        [JsonPropertyName("name")]
        public string? ProductName { get; set; }
        [JsonPropertyName("has_co_production")]
        public bool HasCoProduction { get; set; }
        [JsonPropertyName("warranty_date")]
        public string? WarrantyDate { get; set; }
        [JsonPropertyName("support_email")]
        public string? SupportEmail { get; set; }
        [JsonPropertyName("is_physical_product")]
        public bool IsPhysicalProduct { get; set; }
        [JsonPropertyName("content")]
        public HotmartProductEventObjectContent Content { get; set; }
    }
    public class HotmartProductEventObjectContent
    {
        [JsonPropertyName("has_physical_products")]
        public bool HasPhysicalProducts { get; set; }
        [JsonPropertyName("products")]
        public List<HotmartProductEventObjectContentProduct?> Products { get; set; }
    }
    public class HotmartProductEventObjectContentProduct
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("ucode")]
        public Guid? Ucode { get; set; }
        [JsonPropertyName("name")]
        public string? Name { get; set; }
        [JsonPropertyName("is_physical_product")]
        public bool IsPhysicalProduct { get; set; }
    }
}