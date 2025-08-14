using CommonSolution.Entities.Common;
using CommonSolution.Entities.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProcessExternalWebhookReceiver.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessExternalWebhookReceiver.CrossCutting.DependencyInjection
{
    public static class OptionsInjectionExtension
    {
        public static IServiceCollection AddOptionsInjectionConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<DefaultUserService>(
                configuration.GetSection("DefaultUser"));

            services.Configure<LoggingOptions>(
                configuration.GetSection("LoggingOptions"));

            services.Configure<ServiceExecution>(
                configuration.GetSection("ServiceExecution"));

            return services;
        }
    }
}
