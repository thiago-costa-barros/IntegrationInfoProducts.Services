using CommonSolution.Entities.Common;
using CommonSolution.Entities.CoreSchema;
using Microsoft.Extensions.Options;
using ProcessExternalWebhookReceiver.Application.DTOs.Hotmart.Events;
using ProcessExternalWebhookReceiver.Application.DTOs.Hotmart.Events.Objects;
using ProcessExternalWebhookReceiver.Application.Interfaces.Services;
using ProcessExternalWebhookReceiver.Application.Interfaces.Services.Hotmart.Events;
using ProcessExternalWebhookReceiver.Application.Mappings.Hotmart;

namespace ProcessExternalWebhookReceiver.Application.Services.Hotmart.Events
{
    public class HotmartEventPurchaseService : IHotmartEventPurchaseService
    {
        private readonly IOptions<DefaultUserService> _defaultUser;
        private readonly IPersonService _personService;
        private readonly ICompanyService _companyService;
        private readonly IBusinessUnitService _businessUnitService;
        private readonly IProductService _productService;
        private readonly IProductOfferService _productOfferService;
        public HotmartEventPurchaseService(
            IOptions<DefaultUserService> defaultUser,
            IPersonService personService, 
            ICompanyService companyService,
            IBusinessUnitService businessUnitService,
            IProductService productService,
            IProductOfferService productOfferService)
        {
            _defaultUser = defaultUser;
            _personService = personService;
            _companyService = companyService;
            _businessUnitService = businessUnitService;
            _productService = productService;
            _productOfferService = productOfferService;
        }
        public async Task HandlePurchaseEventsAsync(HotmartEventPayload<HotmartPuchaseEventPayload> hotmartEventPayload, CancellationToken cancellationToken)
        {
            DefaultUserService defaultUser = _defaultUser.Value;
            string? personTaxNumber = hotmartEventPayload.Payload?.Data?.Producer?.Document;
            if (string.IsNullOrEmpty(personTaxNumber))
                throw new InvalidOperationException("O número de documento do produtor não pode ser nulo ou vazio.");
            
            Person producer = HotmartPersonMapping.HotmartProducerMapToPerson(hotmartEventPayload, defaultUser).Result;
            Person producerPerson = await _personService.GetOrCreatePerson(producer, cancellationToken);

            Person buyer = HotmartPersonMapping.HotmartBuyerMapToPerson(hotmartEventPayload, defaultUser).Result;
            Person buyerPerson = await _personService.GetOrCreatePerson(buyer, cancellationToken);

            Company company = await _companyService.GetCompanyById(hotmartEventPayload.CompanyId);

            BusinessUnit businessUnit = await _businessUnitService.GetBusinessUnitById(hotmartEventPayload.BusinessUnitId);

            Product hotmartProduct = HotmartProductMapping.HotmartProductMapToProduct(hotmartEventPayload, businessUnit.BusinessUnitId, defaultUser);
            Product product = await _productService.GetOrCreateProduct(hotmartProduct);

            
        }
    }
}
