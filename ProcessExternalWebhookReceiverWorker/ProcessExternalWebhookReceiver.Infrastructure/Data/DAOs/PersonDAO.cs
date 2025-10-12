using CommonSolution.Entities.CoreSchema;
using CommonSolution.CrossCutting.PostgresSQL;
using ProcessExternalWebhookReceiver.Application.Interfaces.DAOs;
using CommonSolution.CrossCutting.PostgresSQL.Extensions;

namespace ProcessExternalWebhookReceiver.Infrastructure.Data.DAOs
{
    public class PersonDAO : IPersonDAO
    {
        private readonly ApplicationDbContext _context;
        private const string SchemaName = "CoreSchema";
        public PersonDAO(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Person> CreatePerson(Person person, CancellationToken cancellationToken = default)
        {
            _context.Add(person);

            await _context.SaveChangesAsync(cancellationToken);
            return person;
        }

        public async Task<Person?> GetPersonByTaxNumber(string taxNumber, CancellationToken cancellationToken = default)
        {
            var parameters = new (string, object?)[]
            {
                ("_paramTaxNumber", taxNumber )
            };

            await using var command = _context.FunctionCommand(
                SchemaName,
                "GetPersonByTaxNumber",
                parameters);

            await using var reader = await command.ExecuteReaderAsync(cancellationToken);
            Person? entity = await DataReaderMapper.MapToSingleAsync<Person>(reader);

            return entity;
        }

        public Task<Person> UpdatePerson(Person person, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
