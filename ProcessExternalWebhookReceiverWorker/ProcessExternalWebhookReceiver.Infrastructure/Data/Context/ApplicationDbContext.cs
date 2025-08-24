using CommonSolution.Entities.CoreSchema;
using CommonSolution.Entities.IntegrationSchema;
using Microsoft.EntityFrameworkCore;

namespace ProcessExternalWebhookReceiver.Infrastructure.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ExternalWebhookReceiver> ExternalWebhookReceiver { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<Person> Person { get; set; }
    }
}