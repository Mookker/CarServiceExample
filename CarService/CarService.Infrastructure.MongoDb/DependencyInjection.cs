using CarService.AppCore.Interfaces;
using CarService.Infrastructure.MongoDb.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;
using MongoDB.Driver;

namespace CarService.Infrastructure.MongoDb
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddMongoDb(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IMongoClient>(_ =>

                 new MongoClient(new MongoClientSettings()
                 {
                     GuidRepresentation = GuidRepresentation.Standard,
                     Server = new MongoServerAddress(configuration.GetConnectionString("MongoDBServer"))
                 })
            );
            services.AddScoped<ICarsRepository, CarsRepository>();
            services.AddScoped<IRepairOrdersRepository, RepairOrdersRepository>();

            return services;
        }
    }
}
