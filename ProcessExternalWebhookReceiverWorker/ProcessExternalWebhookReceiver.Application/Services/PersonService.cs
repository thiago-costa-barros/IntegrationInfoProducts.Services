using CommonSolution.Entities.CoreSchema;
using ProcessExternalWebhookReceiver.Application.Interfaces.Repositories;
using ProcessExternalWebhookReceiver.Application.Interfaces.Services;

namespace ProcessExternalWebhookReceiver.Application.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }
        public async Task<Person> GetOrCreatePerson(Person person, CancellationToken cancellationToken)
        {
            Person existsPerson = await _personRepository.GetPersonByTaxNumber(person.TaxNumber);
            if (existsPerson == null)
            {
                Person newPerson = await _personRepository.CreatePerson(person, cancellationToken);
                return newPerson;
            }
            return existsPerson;
        }

        public Task<Person> GetPersonByEmail(string email, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Person> GetPersonByTaxNumber(string taxNumber, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
