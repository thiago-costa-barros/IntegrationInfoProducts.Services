using CommonSolution.Helpers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProcessExternalWebhookReceiver.Domain.Entities;

namespace ProcessExternalWebhookReceiver.CrossCutting.DependencyInjection
{
    public static class OptionsInjectionExtension
    {
        public static IServiceCollection AddOptionsInjectionConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddCommonOptions(configuration);

            services.Configure<ServiceExecution>(
                configuration.GetSection("ServiceExecution"));

            return services;
        }
    }
}
