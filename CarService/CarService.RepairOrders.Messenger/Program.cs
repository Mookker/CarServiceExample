using CarService.EventProcessor.Cqrs.Commands.Handlers;
using CarService.EventProcessor.Interfaces;
using CarService.EventProcessor.Services;
using CarService.Infrastructure.MongoDb;
using MediatR;
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
                .ConfigureServices((appContext, services) =>
                    services
                        .AddMongoDb(appContext.Configuration)
                        .AddMediatR(typeof(CreateRepairOrderCommandHandler))
                        .AddScoped<ICommandFactory, CommandFactory>()
                        .AddSingleton<IRepairOrdersListener, RepairOrdersRedisEventListener>());
        }
    }
}
