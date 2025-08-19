using CommonSolution.Entities.Common.Enums;

namespace ProcessExternalWebhookReceiver.Application.DTOs.Hotmart.Events
{
    public class HotmartEventPayload<T>
    {
        public int ExternalWebhookReceiverId { get; set; }
        public ExternalWebhookReceiverSourceType SourceType { get; set; }
        public ExternalWebhookReceiverStatus Status { get; set; }
        public int CompanyId { get; set; }
        public string? ExternalIdentifier { get; set; }
        public HotmartEventPayloadData<T>? Payload { get; set; }
    }

    public class HotmartEventPayloadData<T>
    {
        public string? Id { get; set; }

        public long CreationDate { get; set; }

        public string? Event { get; set; }

        public string? Version { get; set; }

        public T? Data { get; set; }
    }
}