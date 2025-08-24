using CommonSolution.Entities.Common;
using CommonSolution.Entities.Common.Enums;
using CommonSolution.Entities.CoreSchema;
using Microsoft.Extensions.Options;
using ProcessExternalWebhookReceiver.Application.Interfaces.DAOs;
using ProcessExternalWebhookReceiver.Infrastructure.Data.Context;
using ProcessExternalWebhookReceiver.Infrastructure.Data.Context.Extensions.SqlServer;

namespace ProcessExternalWebhookReceiver.Infrastructure.Data.DAOs
{
    public class PersonDAO : IPersonDAO
    {
        private readonly ApplicationDbContext _context;
        private readonly IOptions<DefaultUserService> _defaultUser;
        public PersonDAO(ApplicationDbContext context, IOptions<DefaultUserService> defaultUser)
        {
            _context = context;
            _defaultUser = defaultUser;
        }
        public async Task<Person> CreatePerson(Person person, CancellationToken cancellationToken = default)
        {
            var DateTimeNow = DateTime.UtcNow;
            person.CreationDate = DateTimeNow;
            person.UpdateDate = DateTimeNow;
            person.CreationUserId= _defaultUser.Value.DefaultUserId;
            person.UpdateUserId = _defaultUser.Value.DefaultUserId;

            _context.Add(person);

            await _context.SaveChangesAsync(cancellationToken);
            return person;
        }

        public Task<Person> GetPersonByEmail(string email, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<Person> GetPersonByTaxNumber(string taxNumber, CancellationToken cancellationToken = default)
        {
            var parameters = new (string, object?)[]
            {
                ("@paramTaxNumber", taxNumber )
            };

            await using var command = _context.StoredProcedureCommand(
                "[CoreSchema].[GetPersonByTaxNumber]",
                parameters);

            await using var reader = await command.ExecuteReaderAsync(cancellationToken);
            Person entity = await DataReaderMapper.MapToSingleAsync<Person>(reader);

            return entity;
        }

        public Task<Person> UpdatePerson(Person person, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
