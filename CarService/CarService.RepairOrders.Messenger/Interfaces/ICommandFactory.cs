using CarService.AppCore.Models.EventModels;
using CarService.AppCore.Models.Events;
using MediatR;
using Newtonsoft.Json.Linq;

namespace CarService.EventProcessor.Interfaces
{
    public interface ICommandFactory
    {
        IBaseRequest CreateCommand<T>(BaseEvent<T> @event) where T : JObject;
    }
}
