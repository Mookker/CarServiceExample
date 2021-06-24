using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarService.Cqrs.Queries;
using CarService.Domain.Models;
using GraphQL.Types;
using MediatR;

namespace CarService.Api.GraphQL.GraphQL.Types
{
    public sealed class CreateCarType : InputObjectGraphType<Car>
    {
        public CreateCarType(IMediator mediator)
        {
            Field(x => x.Make).Description("Car manufacturer name");
            Field(x => x.Model).Description("Car model");
            Field(x => x.Year).Description("Year when car was made");
            Field(x => x.Vin).Description("Car VIN code");
            Field(x => x.Millage).Description("Car millage");
            Field(x => x.OwnerId).Description("Identifier of the car owner");
        }
    }
}
