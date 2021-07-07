using CarService.AppCore.Models.EventModels;
using CarService.AppCore.Models.Events;
using CarService.EventProcessor.Cqrs.Commands;
using CarService.EventProcessor.Interfaces;
using CarService.EventProcessor.Сonstants;
using MediatR;
using Newtonsoft.Json.Linq;

namespace CarService.EventProcessor.Services
{
    public class CommandFactory : ICommandFactory
    {
        public IBaseRequest CreateCommand<T>(BaseEvent<T> @event) where T : JObject
        {
            switch (@event.Type)
            {
                case RepairOrderEvents.CreatedEvent:
                    {
                        var eventDataModel = @event.Data.ToObject<RepairOrderCreatedDataModel>();

                        return new CreateRepairOrderCommand
                        {
                            Id = eventDataModel.Id,
                            Price = eventDataModel.Price,
                            CarId = eventDataModel.CarId,
                            OrderDate = eventDataModel.OrderDate,
                        };
                    }

                case RepairOrderEvents.UpdatedEvent:
                    {
                        var eventDataModel = @event.Data.ToObject<RepairOrderUpdatedDataModel>();

                        return new UpdateRepairOrderCommand
                        {
                            Id = eventDataModel.Id,
                            CarId = eventDataModel.CarId,
                            OrderDate = eventDataModel.OrderDate,
                            Price = eventDataModel.Price
                        };
                    }

                case RepairOrderEvents.DeletedEvent:
                    {
                        var eventDataModel = @event.Data.ToObject<RepairOrderDeletedDataModel>();

                        return new DeleteRepairOrderCommand { Id = eventDataModel.Id };
                    }

                default:
                    return null;
            }
        }
    }
}
