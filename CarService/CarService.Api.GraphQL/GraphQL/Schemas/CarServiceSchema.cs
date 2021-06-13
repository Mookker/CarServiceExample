using System;
using CarService.Api.GraphQL.GraphQL.Mutations;
using CarService.Api.GraphQL.GraphQL.Queries;
using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;

namespace CarService.Api.GraphQL.GraphQL.Schemas
{
    public class CarServiceSchema: Schema
    {
        public CarServiceSchema(IServiceProvider provider)
            : base(provider)
        {
            Query = provider.GetRequiredService<CarServiceQuery>();
            Mutation = provider.GetRequiredService<CarServiceMutation>();
        }
    }
}
