namespace ProcessExternalWebhookReceiver.Domain.Entities.Enums
{
    public enum HotmartWebhookEventType
    {
        
        PURCHASE_APPROVED = 1,
        PURCHASE_CANCELED = 2,
        PURCHASE_COMPLETE = 3,
        PURCHASE_BILLET_PRINTED = 4,
        PURCHASE_PROTEST = 5,
        PURCHASE_REFUNDED = 6,
        PURCHASE_CHARGEBACK = 7,
        PURCHASE_EXPIRED = 8,
        PURCHASE_DELAYED = 9,
        SUBSCRIPTION_CANCELLATION = 10,
        SWITCH_PLAN = 11,
        PURCHASE_OUT_OF_SHOPPING_CART = 12,
        UPDATE_SUBSCRIPTION_CHARGE_DATE = 13,
        CLUB_FIRST_ACCESS = 14,
        CLUB_MODULE_COMPLETED = 15,
    }
}
