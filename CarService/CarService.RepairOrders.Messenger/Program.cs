using System;
using CarService.EventProcessor.Cqrs.Commands.Handlers;
using CarService.EventProcessor.Interfaces;
using CarService.EventProcessor.Services;
using CarService.Infrastructure.MongoDb;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CarService.EventProcessor
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            _ = host.Services.GetRequiredService<IRepairOrdersListener>();

            host.Run();
        }

        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration(cfg =>
                {
                    string environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
                    if (!string.IsNullOrWhiteSpace(environment))
                    {
                        cfg.AddJsonFile($"appsettings.{environment}.json", optional: false);
                    }
                })
                .ConfigureServices((appContext, services) =>
                    services
                        .AddMongoDb(appContext.Configuration)
                        .AddMediatR(typeof(CreateRepairOrderCommandHandler))
                        .AddScoped<ICommandFactory, CommandFactory>()
                        .AddSingleton<IRepairOrdersListener, RepairOrdersRedisEventListener>());
        }
    }
}
