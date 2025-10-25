using CommonSolution.Entities.Common;
using CommonSolution.Entities.Common.Enums;
using CommonSolution.Entities.CoreSchema;
using ProcessExternalWebhookReceiver.Application.DTOs.Hotmart.Events;
using ProcessExternalWebhookReceiver.Application.DTOs.Hotmart.Events.Objects;

namespace ProcessExternalWebhookReceiver.Application.Interfaces.Services.Hotmart
{
    public interface IHotmartOperationProcessFactory
    {
        OperationType OperationType { get; }
        Task OperationProcess(HotmartEventPayload<HotmartPuchaseEventPayload> payload, Operation? operation, BusinessUnit businessUnit, Product product, ProductOffer productOffer, DefaultUserService defaultUser);
    }
}
