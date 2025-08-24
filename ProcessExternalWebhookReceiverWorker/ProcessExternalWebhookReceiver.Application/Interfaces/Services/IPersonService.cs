using CommonSolution.Entities.CoreSchema;
using CommonSolution.Entities.IntegrationSchema;

namespace ProcessExternalWebhookReceiver.Application.Interfaces.Services
{
    public interface IPersonService
    {
        Task<Person> GetOrCreatePerson(Person person, CancellationToken cancellationToken);
        Task<Person> GetPersonByTaxNumber(string taxNumber, CancellationToken cancellationToken);
        Task<Person> GetPersonByEmail(string email, CancellationToken cancellationToken);
    }
}
