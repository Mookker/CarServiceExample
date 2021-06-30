using System;
using System.Text.Json.Serialization;

namespace CarService.AppCore.Models.Events
{
    public record BaseEvent<T> where T : class
    {
        public virtual string Type { get; init; }
        public virtual T Data { get; init; }
    }
}
