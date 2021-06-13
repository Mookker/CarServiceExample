using System;

namespace CarService.AppCore.Models.Events
{
    public record RepairOrderCreatedEvent: BaseEvent
    {
        public Guid RepairOrderId { get; init; }
        public double Price { get; init; }
        public DateTime OrderDate { get; init; }
        public Guid CarId { get; init; }
    }
}
