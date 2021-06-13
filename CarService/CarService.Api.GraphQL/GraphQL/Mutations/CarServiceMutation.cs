using CarService.Api.GraphQL.GraphQL.Types;
using CarService.AppCore.Models;
using CarService.Cqrs.Commands;
using CarService.Domain.Models;
using GraphQL;
using GraphQL.Types;
using MediatR;

namespace CarService.Api.GraphQL.GraphQL.Mutations
{
    public class CarServiceMutation: ObjectGraphType
    {
        public CarServiceMutation(IMediator mediator)
        {
            Name = "Mutation";
            Field<CarOwnerType>("createOwner",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<CreateCarOwnerType>> {Name = "carOwner"}
                ), resolve: context =>
                {
                    var user = context.GetArgument<CarOwner>("carOwner");
                    return mediator.Send(new CreateCarOwnerCommand(user));
                });
            Field<RepairOrderType>("createRepairOrder",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<CreateRepairOrderType>>
                    {Name = "repairOrder"}),
                resolve: context =>
                {
                    var repairOrder = context.GetArgument<RepairOrder>("repairOrder");
                    return mediator.Send(new CreateRepairOrderCommand(repairOrder));
                });
        }

    }
}
