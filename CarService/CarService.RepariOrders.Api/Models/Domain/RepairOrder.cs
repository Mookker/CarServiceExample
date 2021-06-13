using System;

namespace CarService.RepariOrders.Api.Models.Domain
{
    public class RepairOrder
    {
        public Guid Id { get; set; }
        public double Price { get; set; }
        public DateTime OrderDate { get; set; }
        public Guid CarId { get; set; }
    }
}
