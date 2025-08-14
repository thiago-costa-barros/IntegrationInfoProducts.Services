using Microsoft.EntityFrameworkCore;
using ProcessExternalWebhookReceiver.CrossCutting.DependencyInjection;
using ProcessExternalWebhookReceiver.Infrastructure.Data.Context;
using ProcessExternalWebhookReceiverWorker;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();

builder.Configuration.AddEnvironmentVariables();

var stringSqlServer = builder.Configuration.GetConnectionString("DefaultConnectionSqlServer");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(stringSqlServer));

builder.Services.AddDependencyInjectionConfig();
builder.Services.AddOptionsInjectionConfig(builder.Configuration);

var host = builder.Build();
host.Run();
