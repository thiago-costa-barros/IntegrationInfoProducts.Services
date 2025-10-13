using CommonSolution.Entities.Common;
using CommonSolution.Entities.CoreSchema;
using Microsoft.Extensions.Options;
using ProcessExternalWebhookReceiver.Application.Interfaces.DAOs;
using ProcessExternalWebhookReceiver.Application.Interfaces.Repositories;

namespace ProcessExternalWebhookReceiver.Infrastructure.Repositories
{
    public class BusinessUnitRepository : IBusinessUnitRepository
    {
        private readonly bool _useCache;
        private readonly IBusinessUnitDAO _businessUnitDAO;
        public BusinessUnitRepository(IOptions<AppSettings> appSettings, IBusinessUnitDAO businessUnitDAO)
        {
            _useCache = appSettings.Value.UseCache;
            _businessUnitDAO = businessUnitDAO;
        }
        public async Task<BusinessUnit?> GetBusinessUnitById(int businessUnitId, CancellationToken cancellationToken = default)
        {
            if (_useCache)
            {
                return null;
            }
            else
            {
                BusinessUnit? businessUnit = await _businessUnitDAO.GetBusinessUnitById(businessUnitId, cancellationToken);
                return businessUnit;
            }
        }
    }
}
