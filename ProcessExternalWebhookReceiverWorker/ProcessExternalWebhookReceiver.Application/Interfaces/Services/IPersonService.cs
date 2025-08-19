using CommonSolution.Entities.CoreSchema;
using CommonSolution.Entities.IntegrationSchema;

namespace ProcessExternalWebhookReceiver.Application.Interfaces.Services
{
    public interface IPersonService
    {
        Task CreateOrUpdateAsync(ExternalWebhookReceiver externalWebhookReceiver, CancellationToken cancellationToken);
        Task<Person> GetPersonByEmail(string email, CancellationToken cancellationToken);
    }
}
