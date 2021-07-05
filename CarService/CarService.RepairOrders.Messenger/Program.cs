using CarService.Infrastructure.MongoDb;
using CarService.RepairOrders.Messenger.Cqrs.Commands.Handlers;
using CarService.RepairOrders.Messenger.Interfaces;
using CarService.RepairOrders.Messenger.Services;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CarService.RepairOrders.Messenger
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            _ = host.Services.GetRequiredService<IEventListener>();

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
                        .AddSingleton<IEventListener, RedisEventListener>());
                        
        }
    }
}
