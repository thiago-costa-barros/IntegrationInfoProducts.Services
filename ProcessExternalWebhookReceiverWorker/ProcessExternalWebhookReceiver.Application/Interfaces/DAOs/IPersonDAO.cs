using CommonSolution.Entities.CoreSchema;

namespace ProcessExternalWebhookReceiver.Application.Interfaces.DAOs
{
    public interface IPersonDAO
    {
        Task<Person> GetPersonByTaxNumber(string taxNumber, CancellationToken cancellationToken = default);
        Task<Person> GetPersonByEmail(string email, CancellationToken cancellationToken = default);
        Task<Person> CreatePerson(Person person, CancellationToken cancellationToken = default);
        Task<Person> UpdatePerson(Person person, CancellationToken cancellationToken = default);
    }
}
