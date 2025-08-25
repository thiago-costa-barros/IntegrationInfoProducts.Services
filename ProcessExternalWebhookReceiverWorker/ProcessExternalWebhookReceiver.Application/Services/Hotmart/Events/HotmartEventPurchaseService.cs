using CommonSolution.Entities.CoreSchema;
using ProcessExternalWebhookReceiver.Application.DTOs.Hotmart.Events;
using ProcessExternalWebhookReceiver.Application.DTOs.Hotmart.Events.Objects;
using ProcessExternalWebhookReceiver.Application.Interfaces.Services;
using ProcessExternalWebhookReceiver.Application.Interfaces.Services.Hotmart.Events;
using ProcessExternalWebhookReceiver.Application.Mappings.Hotmart;

namespace ProcessExternalWebhookReceiver.Application.Services.Hotmart.Events
{
    public class HotmartEventPurchaseService : IHotmartEventPurchaseService
    {
        private readonly IPersonService _personService;

        public HotmartEventPurchaseService(IPersonService personService)
        {
            _personService = personService;
        }
        public async Task HandlePurchaseEventsAsync(HotmartEventPayload<HotmartPuchaseEventPayload> hotmartEventPayload, CancellationToken cancellationToken)
        {
            string personTaxNumber = hotmartEventPayload.Payload?.Data.Producer?.Document;
            if (string.IsNullOrEmpty(personTaxNumber))
                throw new InvalidOperationException("O número de documento do produtor não pode ser nulo ou vazio.");
            
            Person producer = HotmartPersonMapping.HotmartProducerMapToPerson(hotmartEventPayload).Result;
            Person producerPerson = await _personService.GetOrCreatePerson(producer, cancellationToken);

            Person buyer = HotmartPersonMapping.HotmartBuyerMapToPerson(hotmartEventPayload).Result;
            Person buyerPerson = await _personService.GetOrCreatePerson(buyer, cancellationToken);
            //continuar com gets de company, companybranch e person

        }
    }
}
