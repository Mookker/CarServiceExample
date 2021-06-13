using CarService.Domain.Models;
using GraphQL.Types;

namespace CarService.Api.GraphQL.GraphQL.Types
{
    public sealed class CreateRepairOrderType: InputObjectGraphType<RepairOrder>
    {
        public CreateRepairOrderType()
        {
            Field(x => x.Price).Description("Amount of money in the repair order");
            Field(x => x.OrderDate).Description("Date of order creation");
            Field(x => x.CarId).Description("Id of the car");
        }
    }
}
