using System;

namespace CarService.RepariOrders.Api.Models.Responses
{
    public class RepairOrderResponse
    {
        public string Id { get; set; }
        public double Price { get; set; }
        public DateTime OrderDate { get; set; }
        public string CarId { get; set; }
    }
}
