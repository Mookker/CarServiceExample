using System;
using CarService.AppCore.Constants;
using CarService.AppCore.Interfaces;
using CarService.AppCore.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CarService.AppCore
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAppCore(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient(HttpClientNames.UsersClient,
                client => { client.BaseAddress = new Uri(configuration.GetConnectionString("UsersService")); });

            services.AddHttpClient(HttpClientNames.RepairOrdersClient,
                client => { client.BaseAddress = new Uri(configuration.GetConnectionString("RepairOrder")); });

            services.AddScoped<IUsersService, UsersService>();
            services.AddScoped<IRepairOrdersService, RepairOrdersService>();
            //services.AddSingleton<IEventListener, RedisEventListener>();


            return services;
        }
    }
}
