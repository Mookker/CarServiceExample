using CarService.Domain.Models;
using CarService.Cqrs.Queries;
using GraphQL.Types;
using MediatR;

namespace CarService.Api.GraphQL.GraphQL.Types
{
    public sealed class RepairOrderType : ObjectGraphType<RepairOrder>
    {
        public RepairOrderType(IMediator mediator)
        {
            Name = nameof(RepairOrder);
            Description = "Repair Order description";
            Field(x => x.Id).Description("Identifier of the repair order");
            Field(x => x.Price).Description("Amount of money in the repair order");
            Field(x => x.OrderDate).Description("Date of order creation");

            Field<CarType>("car", "car details", resolve: context => mediator.Send(new GetCarByIdQuery(context.Source.CarId)));
        }
    }
}
