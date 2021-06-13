using CarService.AppCore.Models;
using CarService.Domain.Models;
using GraphQL.Types;

namespace CarService.Api.GraphQL.GraphQL.Types
{
    public sealed class CreateCarOwnerType: InputObjectGraphType<CarOwner>
    {
        public CreateCarOwnerType()
        {
            Field(x => x.FirstName).Description("First name");
            Field(x => x.LastName).Description("Last name");
            Field(x => x.DoB).Description("Date of birthday");
            Field(x => x.CarId).Description("Identifier of the car");
        }
    }
}
