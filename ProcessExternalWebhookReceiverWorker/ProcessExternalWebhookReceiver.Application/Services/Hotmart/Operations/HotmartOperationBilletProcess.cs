using CommonSolution.Entities.Common;
using CommonSolution.Entities.Common.Enums;
using CommonSolution.Entities.CoreSchema;
using ProcessExternalWebhookReceiver.Application.DTOs.Hotmart.Events;
using ProcessExternalWebhookReceiver.Application.DTOs.Hotmart.Events.Objects;
using ProcessExternalWebhookReceiver.Application.Interfaces.Services.Hotmart;

namespace ProcessExternalWebhookReceiver.Application.Services.Hotmart.Operations
{
    public class HotmartOperationBilletProcess: IHotmartOperationProcessFactory
    {
        public OperationType OperationType => OperationType.Billet;
        public async Task OperationProcess(HotmartEventPayload<HotmartPuchaseEventPayload> payload, Operation? operation, BusinessUnit businessUnit, Product product, ProductOffer productOffer, DefaultUserService defaultUser)
        {
            if (operation == null)
            {
                // Criar Operation e entidades relacionadas (Billet)
            }
            else
            {
                // Atualizar operação Billet
            }
            await Task.CompletedTask;
        }
    }
}
