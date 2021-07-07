using CarService.AppCore.Models.EventModels;

namespace CarService.AppCore.Models.Events
{
    public record RepairOrderCreatedEvent : BaseEvent<RepairOrderCreatedDataModel>
    {
    }
}
