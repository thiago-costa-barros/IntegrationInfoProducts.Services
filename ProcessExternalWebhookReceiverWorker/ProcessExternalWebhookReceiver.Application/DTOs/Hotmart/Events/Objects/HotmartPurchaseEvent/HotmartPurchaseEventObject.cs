using System.Text.Json;
using System.Text.Json.Serialization;

namespace ProcessExternalWebhookReceiver.Application.DTOs.Hotmart.Events.Objects.HotmartPurchaseEvent
{
    public class HotmartPurchaseEventObject
    {
        [JsonPropertyName("approved_date")]
        public long ApprovedDate { get; set; }
        [JsonPropertyName("full_price")]
        public HotmartPurchaseEventObjectPrice? FullPrice { get; set; }
        [JsonPropertyName("original_offer_price")]
        public HotmartPurchaseEventObjectPrice? OriginalOfferPrice { get; set; }
        [JsonPropertyName("price")]
        public HotmartPurchaseEventObjectPrice? Price { get; set; }
        [JsonPropertyName("recurrence_number")]
        public int RecurrenceNumber { get; set; }
        [JsonPropertyName("subscription_anticipation_purchase")]
        public bool SubscriptionAnticipationPurchase { get; set; }
        [JsonPropertyName("offer")]
        public HotmartPurchaseEventObjectOffer? Offer { get; set; }
        [JsonPropertyName("origin")]
        public HotmartPurchaseEventObjectOrigin? Origin { get; set; }
        [JsonPropertyName("checkout_country")]
        public HotmartPurchaseEventObjectCheckoutCountry? CheckoutCountry { get; set; }
        [JsonPropertyName("order_bump")]
        public HotmartPurchaseEventObjectOrderBump? OrderBump { get; set; }
        [JsonPropertyName("order_date")]
        public long OrderDate { get; set; }
        [JsonPropertyName("date_next_charge")]
        public long DateNextCharge { get; set; }
        [JsonPropertyName("status")]
        public string? Status { get; set; }
        [JsonPropertyName("transaction")]
        public string? Transaction { get; set; }
        [JsonPropertyName("payment")]
        public HotmartPurchaseEventObjectPayment? Payment { get; set; }
        [JsonPropertyName("is_funnel")]
        public bool IsFunnel { get; set; }
        [JsonPropertyName("event_tickets")]
        public HotmartPurchaseEventObjectEventTickets? EventTickets { get; set; }
        [JsonPropertyName("business_model")]
        public string? BusinessModel { get; set; }
    }

    public class HotmartPurchaseEventObjectPrice
    {
        [JsonPropertyName("value")]
        public decimal Value { get; set; }

        [JsonPropertyName("currency_value")]
        public string? CurrencyValue { get; set; }
    }
    public class HotmartPurchaseEventObjectOffer
    {
        [JsonPropertyName("code")]
        public string? Code { get; set; }
        [JsonPropertyName("coupon_code")]
        public string? CouponCode { get; set; }
        [JsonPropertyName("name")]
        public string? Name { get; set; }
        [JsonPropertyName("description")]
        public string? Description { get; set; }
    }
    public class HotmartPurchaseEventObjectOrigin
    {
        [JsonPropertyName("Scr")]
        public string? Scr { get; set; }
        [JsonPropertyName("sck")]
        public string? Sck { get; set; }
        [JsonPropertyName("xcod")]
        public string? Xcod { get; set; }
    }
    public class HotmartPurchaseEventObjectCheckoutCountry
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }
        [JsonPropertyName("iso")]
        public string? Iso { get; set; }
    }
    public class HotmartPurchaseEventObjectOrderBump
    {
        [JsonPropertyName("is_order_bump")]
        public bool IsOrderBump { get; set; }
        [JsonPropertyName("parent_purchase_transaction")]
        public string? ParentPurchaseTransaction { get; set; }
    }
    public class HotmartPurchaseEventObjectPayment
    {
        [JsonPropertyName("billet_barcode")]
        public string? BilletBarcode { get; set; }
        [JsonPropertyName("billet_url")]
        public string? BilletUrl { get; set; }
        [JsonPropertyName("installments_number")]
        public int InstallmentsNumber { get; set; }
        [JsonPropertyName("pix_code")]
        public string? PixCode { get; set; }
        [JsonPropertyName("pix_expiration_date")]
        public long PixExpirationDate { get; set; }
        [JsonPropertyName("pix_qrcode")]
        public string? PixQrcode { get; set; }
        [JsonPropertyName("refusal_reason")]
        public string? RefusalReason { get; set; }
        [JsonPropertyName("type")]
        public string? Type { get; set; }
    }
    public class HotmartPurchaseEventObjectEventTickets
    {
        [JsonPropertyName("amount")]
        public long Amount { get; set; }
    }
}
