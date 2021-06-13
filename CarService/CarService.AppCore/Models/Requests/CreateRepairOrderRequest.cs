using System;

namespace CarService.AppCore.Models.Requests
{
    public record CreateRepairOrderRequest
    {
        public double Price { get; init; }
        public Guid CarId { get; init;}
        public DateTime OrderDate { get; init;}
    }
}
