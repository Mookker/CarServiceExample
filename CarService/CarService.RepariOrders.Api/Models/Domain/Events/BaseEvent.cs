using System;

namespace CarService.RepariOrders.Api.Models.Domain.Events
{
    public abstract record BaseEvent
    {
        protected BaseEvent()
        {
            Id = Guid.NewGuid();
            CreatedDate = DateTime.UtcNow;
        }
        public Guid Id { get; }
        public DateTime CreatedDate { get; }
    }
}
