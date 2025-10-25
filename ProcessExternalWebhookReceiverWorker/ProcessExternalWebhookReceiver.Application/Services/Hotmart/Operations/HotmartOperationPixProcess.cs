using CommonSolution.Entities.Common;
using CommonSolution.Entities.Common.Enums;
using CommonSolution.Entities.CoreSchema;
using ProcessExternalWebhookReceiver.Application.DTOs.Hotmart.Events;
using ProcessExternalWebhookReceiver.Application.DTOs.Hotmart.Events.Objects;
using ProcessExternalWebhookReceiver.Application.Interfaces.Services;
using ProcessExternalWebhookReceiver.Application.Interfaces.Services.Hotmart;
using ProcessExternalWebhookReceiver.Application.Mappings.Hotmart;

namespace ProcessExternalWebhookReceiver.Application.Services.Hotmart.Operations
{
    public class HotmartPixOperationProcess : IHotmartOperationProcessFactory
    {
        private readonly IOperationService _operationService;
        private readonly IOperationPixService _operationPixService;
        public HotmartPixOperationProcess(IOperationService operationService, IOperationPixService operationPixService)
        {
            _operationService = operationService;
            _operationPixService = operationPixService;
        }
        public OperationType OperationType => OperationType.Pix;
        public async Task OperationProcess(HotmartEventPayload<HotmartPuchaseEventPayload> payload, Operation? operation, BusinessUnit businessUnit, Product product, ProductOffer productOffer, DefaultUserService defaultUser)
        {
            if (operation == null)
            {
                OperationStatus operationStatus = HotmartOperationMapping.HotmartMappingToOperationStatus(payload.Payload?.Data?.Purchase?.Status);
                OperationPix hotmartOperationPix = HotmartOperationMapping.HotmartMappingToOperationPix(payload, operationStatus, defaultUser);
                OperationPix operationPix = await _operationPixService.InsertOperationPix(hotmartOperationPix);

                Operation hotmartOperation = HotmartOperationMapping.HotmartMappingToOperation(payload, OperationType.Pix, operationStatus, product, productOffer, operationPix.OperationPixId, null, defaultUser);
                Operation newOperation = await _operationService.InsertOperation(hotmartOperation);
            }
            else
            {
                // Atualizar operação Pix
            }

            await Task.CompletedTask;
        }
    }
}
