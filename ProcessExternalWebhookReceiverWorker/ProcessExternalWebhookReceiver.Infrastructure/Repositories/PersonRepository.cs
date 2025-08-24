using CommonSolution.Entities.Common;
using CommonSolution.Entities.CoreSchema;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using ProcessExternalWebhookReceiver.Application.Interfaces.DAOs;
using ProcessExternalWebhookReceiver.Application.Interfaces.Repositories;

namespace ProcessExternalWebhookReceiver.Infrastructure.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly bool _useCache;
        private readonly IPersonDAO _personDAO;
        public PersonRepository(IOptions<AppSettings> appSettings, IPersonDAO person)
        {
            _useCache = appSettings.Value.UseCache;
            _personDAO = person;
        }
        public Task<Person> CreatePerson(Person person, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Person> GetPersonByEmail(string email, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<Person> GetPersonByTaxNumber(string taxNumber, CancellationToken cancellationToken = default)
        {
            if (_useCache)
            {
                // Try to get from cache
                // For now, return null if not implemented
                return null;
            }
            else
            {
                Person person = await _personDAO.GetPersonByTaxNumber(taxNumber);
                return person;
            }
        }

        public Task<Person> UpdatePerson(Person person, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
