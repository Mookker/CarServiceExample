using System;
using CarService.Api.GraphQL.GraphQL.Mutations;
using CarService.Api.GraphQL.GraphQL.Queries;
using CarService.Api.GraphQL.GraphQL.Schemas;
using CarService.Api.GraphQL.GraphQL.Types;
using CarService.AppCore;
using CarService.AppCore.Constants;
using CarService.AppCore.Interfaces;
using CarService.Cqrs.Queries;
using CarService.Infrastructure.MongoDb;
using GraphQL.Server;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using CarService.AppCore.Services;
using CarService.Cqrs.Queries.Handlers;

namespace CarService.Api.GraphQL
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMongoDb(Configuration);
            services.AddAppCore(Configuration);

            services.AddScoped<CarServiceQuery>();
            services.AddScoped<CarServiceMutation>();
            services.AddScoped<CarType>();
            services.AddScoped<RepairOrderType>();
            services.AddScoped<CarOwnerType>();
            services.AddScoped<CreateCarOwnerType>();
            services.AddScoped<CreateRepairOrderType>();
            services.AddScoped<CreateCarType>();
            services.AddScoped<ISchema, CarServiceSchema>();

            services.AddGraphQL(options =>
                {
                    options.EnableMetrics = true;
                })
                .AddErrorInfoProvider(opt => opt.ExposeExceptionStackTrace = true)
                .AddSystemTextJson();

            services.AddMediatR(typeof(GetCarQueryHandler));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // add http for Schema at default url /graphql
            app.UseGraphQL<ISchema>();

            // use graphql-playground at default url /ui/playground
            app.UseGraphQLPlayground();

            //app.UseHttpsRedirection();
        }
    }
}
