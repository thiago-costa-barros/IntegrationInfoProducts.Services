using CommonSolution.Entities.CoreSchema;
using CommonSolution.Entities.IntegrationSchema;
using ProcessExternalWebhookReceiver.Application.Interfaces.Services;

namespace ProcessExternalWebhookReceiver.Application.Services
{
    public class PersonService : IPersonService
    {
        public Task CreateOrUpdateAsync(ExternalWebhookReceiver externalWebhookReceiver, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Person> GetPersonByEmail(string email, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
