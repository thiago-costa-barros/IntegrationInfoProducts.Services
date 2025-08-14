using CommonSolution.Handlers;
using CommonSolution.Interfaces.Logging;
using Microsoft.Extensions.DependencyInjection;
using ProcessExternalWebhookReceiver.Application;
using ProcessExternalWebhookReceiver.Infrastructure;
using ProcessExternalWebhookReceiver.Infrastructure.Data.Context;

namespace ProcessExternalWebhookReceiver.CrossCutting.DependencyInjection
{
    public static class InjectionExtension
    {
        public static IServiceCollection AddDependencyInjectionConfig(this IServiceCollection services)
        {
            // Infrastructure
            services.AddDbContext<ApplicationDbContext>();

            // Unit of Work
            //services.AddScoped<IDbTransaction, DbTransaction>();

            //Services
            services.AddServices();

            //Repositories
            services.AddRepositories();

            //Data Object Access
            services.AddDataObjectAccess();

            //Logging
            services.AddLogging();

            return services;
        }

        private static void AddServices(this IServiceCollection services)
        {
            services.Scan(scan => scan
                .FromAssemblyOf<AssemblyReferenceApplication>()
                .AddClasses(c => c.Where(t => t.Name.EndsWith("Service")))
                .AsImplementedInterfaces()
                .WithScopedLifetime());
        }
        private static void AddRepositories(this IServiceCollection services)
        {
            services.Scan(scan => scan
                .FromAssemblyOf<AssemblyReferenceInfrastructure>()
                .AddClasses(c => c.Where(t => t.Name.EndsWith("Repository")))
                .AsImplementedInterfaces()
                .WithScopedLifetime());
        }
        private static void AddDataObjectAccess(this IServiceCollection services)
        {
            services.Scan(scan => scan
                .FromAssemblyOf<AssemblyReferenceInfrastructure>()
                .AddClasses(c => c.Where(t => t.Name.EndsWith("DAO")))
                .AsImplementedInterfaces()
                .WithScopedLifetime());
        }
        private static void AddLogging(this IServiceCollection services)
        {
            services.AddSingleton<ILogHandler, ElasticLogHandler>();
        }
    }
}
