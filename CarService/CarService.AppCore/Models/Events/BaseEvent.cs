using CarService.AppCore.Interfaces;
using CarService.AppCore.Models.EventModels;
using CarService.Domain.Models;
using System;
using System.Text.Json.Serialization;

namespace CarService.AppCore.Models.Events
{
    public record BaseEvent<T> where T : class
    {
        public Guid Id { get; }
        public DateTime CreatedDate { get; }
        public virtual string Type { get; init; }
        public virtual T Data { get; init; }

        public BaseEvent()
        {
            Id = Guid.NewGuid();
            CreatedDate = DateTime.UtcNow;
        }
    }
}
