using CarService.Authentication.Interfaces;
using CarService.Authentication.Services;
using CarService.Users.Api.Configurations;
using CarService.Users.Api.Cqrs.Queries.Handlers;
using CarService.Users.Api.Interfaces;
using CarService.Users.Api.Models.Domain;
using CarService.Users.Api.Repositories;
using Dapper.Extensions.PostgreSql;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace CarService.Authentication
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
            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddSingleton<Interfaces.ITokenConfiguration, TokenConfiguration>();
            services.AddScoped<ITokenGenerator, TokenGenerator>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddTransient<IPasswordHasher<User>, PasswordHasher<User>>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CarService.Authentication", Version = "v1" });
            });

            services.AddMediatR(typeof(GetUserByUsernameQueryHandler));

            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CarService.Authentication v1"));
            }

            app.UseAuthentication();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
