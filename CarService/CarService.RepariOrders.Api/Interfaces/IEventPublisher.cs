using System.Threading.Tasks;
using CarService.RepariOrders.Api.Models.Domain.Events;

namespace CarService.RepariOrders.Api.Interfaces
{
    public interface IEventPublisher
    {
        Task PublishEvent<T>(string topic, T @event) where T: BaseEvent;
    }
}
