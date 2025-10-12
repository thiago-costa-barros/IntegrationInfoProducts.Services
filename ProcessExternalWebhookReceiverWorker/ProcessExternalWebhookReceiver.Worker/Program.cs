using CommonSolution.CrossCutting.PostgresSQL;
using ProcessExternalWebhookReceiver.CrossCutting.DependencyInjection;
using ProcessExternalWebhookReceiverWorker;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();

builder.Configuration.AddEnvironmentVariables();

builder.Services.AddOptionsInjectionConfig(builder.Configuration);
builder.Services.AddDependencyInjectionConfig();
builder.Services.AddDatabaseConfig(builder.Configuration);

var host = builder.Build();
host.Run();
