using CommonSolution.Entities.Common.Enums;
using CommonSolution.Entities.CoreSchema;
using ProcessExternalWebhookReceiver.Application.DTOs.Hotmart.Events;
using ProcessExternalWebhookReceiver.Application.DTOs.Hotmart.Events.Objects;

namespace ProcessExternalWebhookReceiver.Application.Mappings
{
    public class PersonMapping
    {
        public static Task<Person> HotmartProducerMapToPerson(HotmartEventPayload<HotmartPuchaseEventPayload> hotmartEventPayload)
        {
            PersonType personType = MapPersonTypeFromProducerHotmart(hotmartEventPayload).Result;
            Person person = new Person
            {
                TaxNumber = hotmartEventPayload.Payload?.Data.Producer?.Document,
                Name = hotmartEventPayload.Payload?.Data.Producer?.Name,
                Email = hotmartEventPayload.Payload?.Data.Product.SupportEmail,
                Type = personType
            };
            return Task.FromResult(person);
        }
        public static Task<Person> HotmartBuyerMapToPerson(HotmartEventPayload<HotmartPuchaseEventPayload> hotmartEventPayload)
        {
            PersonType personType = MapPersonTypeFromBuyerHotmart(hotmartEventPayload).Result;
            Person person = new Person
            {
                TaxNumber = hotmartEventPayload.Payload?.Data.Buyer?.Document,
                Name = hotmartEventPayload.Payload?.Data.Buyer?.Name,
                Email = hotmartEventPayload.Payload?.Data.Buyer?.Email,
                Type = personType
            };
            return Task.FromResult(person);
        }
        private static Task<PersonType> MapPersonTypeFromProducerHotmart(HotmartEventPayload<HotmartPuchaseEventPayload> hotmartEventPayload)
        {
            string personType = hotmartEventPayload.Payload?.Data.Producer?.LegalNature;
            switch (personType)
            {
                case "Pessoa Física":
                    return Task.FromResult(PersonType.Individual);
                case "Pessoa Jurídica":
                    return Task.FromResult(PersonType.LegalEntity);
                default:
                    return Task.FromResult(PersonType.ForeignPerson);
            }
        }
        private static Task<PersonType> MapPersonTypeFromBuyerHotmart(HotmartEventPayload<HotmartPuchaseEventPayload> hotmartEventPayload)
        {
            string personType = hotmartEventPayload.Payload?.Data.Producer?.LegalNature;
            switch (personType)
            {
                case "CPF":
                    return Task.FromResult(PersonType.Individual);
                case "CNPJ":
                    return Task.FromResult(PersonType.LegalEntity);
                default:
                    return Task.FromResult(PersonType.ForeignPerson);
            }
        }
    }
}
