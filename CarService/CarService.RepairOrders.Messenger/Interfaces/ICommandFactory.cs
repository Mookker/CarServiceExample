using CarService.AppCore.Models.EventModels;
using CarService.AppCore.Models.Events;
using MediatR;
using Newtonsoft.Json.Linq;

namespace CarService.RepairOrders.Messenger.Interfaces
{
    public interface ICommandFactory
    {
        IBaseRequest CreateCommand<T>(BaseEvent<T> @event) where T : JObject;
    }
}
