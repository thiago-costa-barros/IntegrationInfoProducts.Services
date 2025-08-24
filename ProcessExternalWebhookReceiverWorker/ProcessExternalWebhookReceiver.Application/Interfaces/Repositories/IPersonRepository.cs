using CommonSolution.Entities.CoreSchema;

namespace ProcessExternalWebhookReceiver.Application.Interfaces.Repositories
{
    public interface IPersonRepository
    {
        Task<Person> GetPersonByTaxNumber(string taxNumber, CancellationToken cancellationToken = default);
        Task<Person> GetPersonByEmail(string email, CancellationToken cancellationToken = default);
        Task<Person> CreatePerson(Person person, CancellationToken cancellationToken = default);
        Task<Person> UpdatePerson(Person person, CancellationToken cancellationToken = default);
    }
}
