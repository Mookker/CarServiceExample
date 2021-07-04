using CarService.AppCore.Models.EventModels;
using CarService.Domain.Models;
using System;

namespace CarService.AppCore.Models.Events
{
    public record RepairOrderCreatedEvent : BaseEvent<RepairOrderRedisEventDataModel>
    {
    }
}
