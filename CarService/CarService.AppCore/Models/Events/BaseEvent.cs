using System;

namespace CarService.AppCore.Models.Events
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
