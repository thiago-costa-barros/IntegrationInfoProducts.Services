using CommonSolution.Entities.CoreSchema;
using ProcessExternalWebhookReceiver.Application.Interfaces.Repositories;
using ProcessExternalWebhookReceiver.Application.Interfaces.Services;
using System.ComponentModel.Design;

namespace ProcessExternalWebhookReceiver.Application.Services
{
    public class BusinessUnitService : IBusinessUnitService
    {
        private readonly IBusinessUnitRepository _businessUnitRepository;
        public BusinessUnitService(IBusinessUnitRepository businessUnitRepository)
        {
            _businessUnitRepository = businessUnitRepository;
        }

        public async Task<BusinessUnit?> GetBusinessUnitById(int businessUnitId, CancellationToken cancellationToken = default)
        {
            BusinessUnit? businessUnit = await _businessUnitRepository.GetBusinessUnitById(businessUnitId);
            if (businessUnit == null)
                throw new KeyNotFoundException($"BusinessUnit with Id {businessUnitId} not found.");
            return businessUnit;
        }
    }
}
