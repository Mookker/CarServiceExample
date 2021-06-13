using CarService.AppCore.Models;
using CarService.Domain.Models;
using GraphQL.Types;

namespace CarService.Api.GraphQL.GraphQL.Types
{
    public sealed class CarOwnerType: ObjectGraphType<CarOwner>
    {
        public CarOwnerType()
        {
            Name = "CarOwner";
            Description = "Car owner details";
            Field(x => x.Id).Description("Identifier of the car owner");
            Field(x => x.FirstName).Description("First name");
            Field(x => x.LastName).Description("Last name");
            Field(x => x.DoB).Description("Date of birthday");
        }
    }
}
