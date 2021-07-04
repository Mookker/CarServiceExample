using System;

namespace CarService.RepariOrders.Api.Models.Responses
{
    public class RepairOrderResponse
    {
        public Guid Id { get; set; }
        public double Price { get; set; }
        public DateTime OrderDate { get; set; }
        public Guid CarId { get; set; }
    }
}
