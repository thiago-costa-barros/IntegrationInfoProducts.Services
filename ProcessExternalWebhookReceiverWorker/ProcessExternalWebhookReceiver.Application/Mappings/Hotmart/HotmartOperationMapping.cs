using CommonSolution.Entities.Common;
using CommonSolution.Entities.Common.Enums;
using CommonSolution.Entities.CoreSchema;
using ProcessExternalWebhookReceiver.Application.DTOs.Hotmart.Events;
using ProcessExternalWebhookReceiver.Application.DTOs.Hotmart.Events.Objects;

namespace ProcessExternalWebhookReceiver.Application.Mappings.Hotmart
{
    public class HotmartOperationMapping
    {
        public static OperationType HotmartMappingOperationType(string? operationType)
        {
            return operationType?.ToUpperInvariant() switch
            {
                "PIX" => OperationType.Pix,
                "BILLET" => OperationType.Billet,
                "FINANCED_BILLET" => OperationType.Billet,
                "HYBRID" => OperationType.HybridBillet,
                "DIRECT_BANK_TRANSFER" => OperationType.BankTransfer,
                "MANUAL_TRANSFER" => OperationType.BankTransfer,
                "DIRECT_DEBIT" => OperationType.BankTransfer,
                "CASH_PAYMENT" => OperationType.BankTransfer,
                "CREDIT_CARD" => OperationType.PurchaseCard,
                "FINANCED_INSTALLMENT" => OperationType.PurchaseCard,
                "HOTCARD" => OperationType.PurchaseCard,
                "WALLET" => OperationType.DigitalWallet,
                "PAYPAL" => OperationType.DigitalWallet,
                "PAYPAL_INTERNACIONAL" => OperationType.DigitalWallet,
                "PICPAY" => OperationType.DigitalWallet,
                "GOOGLE_PAY" => OperationType.DigitalWallet,
                "WASAMSUNG_PAYLLET" => OperationType.DigitalWallet,
                _ => throw new NotSupportedException($"Tipo de pagamento não suportado: {operationType}")
            };
        }
        public static OperationStatus HotmartMappingToOperationStatus(string? status)
        {
            return status?.ToUpperInvariant() switch
            {
                "APPROVED" => OperationStatus.Approved,
                "BLOCKED" => OperationStatus.AwaitingConfirmation,
                "CANCELLED" => OperationStatus.Cancelled,
                "CHARGEBACK" => OperationStatus.AwaitingConfirmation,
                "COMPLETE" => OperationStatus.Completed,
                "EXPIRED" => OperationStatus.Cancelled,
                "NO_FUNDS" => OperationStatus.Cancelled,
                "OVERDUE" => OperationStatus.Cancelled,
                "PARTIALLY_REFUNDED" => OperationStatus.Refunded,
                "PRE_ORDER" => OperationStatus.Pending,
                "PRINTED_BILLET" => OperationStatus.Registred,
                "PROCESSING_TRANSACTION " => OperationStatus.Pending,
                "DISPUTE" => OperationStatus.AwaitingConfirmation,
                "REFUNDED" => OperationStatus.Refunded,
                "STARTED" => OperationStatus.Pending,
                "UNDER_ANALISYS" => OperationStatus.AwaitingConfirmation,
                "WAITING_PAYMENT" => OperationStatus.Registred,
                _ => throw new NotSupportedException($"Status de operação não suportado: {status}")
            };
        }
        public static Operation HotmartMappingToOperation(HotmartEventPayload<HotmartPuchaseEventPayload> hotmartEventPayload, OperationType operationType, OperationStatus operationStatus, Product product, ProductOffer productOffer, int entityId, string receiptFileName = null,  DefaultUserService defaultUser)
        {
            var operation = new Operation
            {
                ProductId = product.ProductId,
                ProductOfferId = productOffer.ProductOfferId,
                Status = operationStatus,
                PrincipalValue = hotmartEventPayload.Payload?.Data?.Purchase?.FullPrice?.Value ?? 0,
                OperationType = operationType,
                EntityId = entityId,
                OperationDate = DateTimeOffset.FromUnixTimeMilliseconds(hotmartEventPayload.Payload?.Data?.Purchase?.OrderDate ?? 0).UtcDateTime,
                WarrantyDate = Convert.ToDateTime(hotmartEventPayload.Payload?.Data?.Product?.WarrantyDate),
                Identifier = hotmartEventPayload.Payload?.Data?.Purchase?.Transaction,
                ReceiptFileName = receiptFileName,
                BusinessUnitId = hotmartEventPayload.BusinessUnitId,
                CreationUserId = defaultUser.DefaultUserId,
                UpdateUserId = defaultUser.DefaultUserId
            };
            return operation;
        }
        public static OperationPix HotmartMappingToOperationPix(HotmartEventPayload<HotmartPuchaseEventPayload> hotmartEventPayload, OperationStatus operationStatus, DefaultUserService defaultUser)
        {
            long? operationDateTimestamp = hotmartEventPayload.Payload?.Data?.Purchase?.OrderDate;
            DateTime operationDate = DateTimeOffset.FromUnixTimeMilliseconds(operationDateTimestamp.Value).UtcDateTime;
            long? transferDateTimestamp = hotmartEventPayload.Payload?.Data?.Purchase?.ApprovedDate;
            DateTime? transferDate = transferDateTimestamp.HasValue
                ? DateTimeOffset.FromUnixTimeMilliseconds(transferDateTimestamp.Value).UtcDateTime
                : (DateTime?)null;
            long? expirationDateTimestamp = hotmartEventPayload.Payload?.Data?.Purchase?.Payment?.PixExpirationDate;
            DateTime expirationDate = DateTimeOffset.FromUnixTimeMilliseconds(expirationDateTimestamp.Value).UtcDateTime;

            var operationPix = new OperationPix
            {
                OperationDate = operationDate,
                TransferDate = transferDate,
                ExpirationDate = expirationDate,
                PrincipalValue = hotmartEventPayload.Payload?.Data?.Purchase?.FullPrice?.Value ?? 0,
                Status = operationStatus,
                HashCode = hotmartEventPayload.Payload?.Data?.Purchase?.Payment?.PixCode,
                QrCodeImageUrl = hotmartEventPayload.Payload?.Data?.Purchase?.Payment?.PixQrcode,
                ConciliationId = hotmartEventPayload.Payload?.Data?.Purchase?.Transaction,
                BusinessUnitId = hotmartEventPayload.BusinessUnitId,
                CreationUserId = defaultUser.DefaultUserId,
                UpdateUserId = defaultUser.DefaultUserId
            };
            return operationPix;
        }
    }
}
