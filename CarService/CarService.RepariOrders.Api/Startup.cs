using CarService.AppCore.Interfaces;
using CarService.AppCore.Services;
using CarService.RepairOrders.Api.Configurations;
using CarService.RepairOrders.Api.Interfaces;
using CarService.RepariOrders.Api.Interfaces;
using CarService.RepariOrders.Api.Repositories;
using Dapper.Extensions.PostgreSql;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace CarService.RepariOrders.Api
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
            services.AddDapperForPostgreSQL();
            services.AddScoped<IRepairOrderRepository, RepairOrderRepository>();
            services.AddScoped<AppCore.Interfaces.IRepairOrdersService, CarService.RepariOrders.Api.Services.RepairOrdersService>();
            services.AddSingleton<IEventPublisher, RedisEventPublisher>();
            services.AddSingleton<ITokenConfiguration, TokenConfiguration>();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "CarService.RepariOrders.Api", Version = "v1"});
            });
            services.AddAutoMapper(typeof(Startup).Assembly);
            services.AddSingleton(Configuration);

            var tokenConfiguration = new TokenConfiguration(Configuration);
            var authPolicy = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme)
               .RequireAuthenticatedUser()
               .Build();

            services.AddAuthentication(o =>
            {
                o.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                o.TokenValidationParameters.ValidateIssuer = true;
                o.TokenValidationParameters.ValidIssuer = tokenConfiguration.Issuer;
                o.TokenValidationParameters.ValidateIssuerSigningKey = true;
                o.TokenValidationParameters.IssuerSigningKey =
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenConfiguration.Secret));
                o.TokenValidationParameters.ValidateAudience = false;
                o.TokenValidationParameters.ValidateLifetime = true;
            });

            services.AddAuthorization(auth => auth.AddPolicy("Baerer", authPolicy));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CarService.RepariOrders.Api v1"));
            }

            app.UseAuthentication();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
