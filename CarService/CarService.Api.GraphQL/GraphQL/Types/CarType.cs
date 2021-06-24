using CarService.Cqrs.Queries;
using CarService.Domain.Models;
using GraphQL.Types;
using MediatR;

namespace CarService.Api.GraphQL.GraphQL.Types
{
    public sealed class CarType: ObjectGraphType<Car>
    {
        public CarType(IMediator mediator)
        {
            Name = nameof(Car);
            Description = "Car description";
            Field(x => x.Id).Description("Identifier of the car");
            Field(x => x.Make).Description("Car manufacturer name");
            Field(x => x.Model).Description("Car model");
            Field(x => x.Year).Description("Year when car was made");
            Field(x => x.Vin).Description("Car VIN code");
            Field(x => x.Millage).Description("Car millage");

            Field<CarOwnerType>("carOwner", "Car owner details",
                resolve: context => mediator.Send(new GetUserByIdQuery(context.Source.OwnerId)));

            Field<ListGraphType<RepairOrderType>>("repairOrders", "Car Repair Orders",
                resolve: context => mediator.Send(new GetCarRepairOrdersQuery(context.Source.Id)));
        }
    }
}
