using System;
using CarService.Api.GraphQL.GraphQL.Types;
using GraphQL;
using GraphQL.Types;
using CarService.Cqrs.Queries;
using MediatR;

namespace CarService.Api.GraphQL.GraphQL.Queries
{
    public class CarServiceQuery : ObjectGraphType
    {
        public CarServiceQuery(IMediator mediator)
        {
            Name = "Query";
            Field<CarType>("car", arguments: new QueryArguments(
                new QueryArgument<NonNullGraphType<StringGraphType>> {Name = "id", Description = "id of the car"}
            ), resolve: context => mediator.Send(new GetCarQueryById(context.GetArgument<Guid>("id"))));
        }
    }
}
