using CarService.AppCore.Models.Events;
using System.Threading.Tasks;

namespace CarService.AppCore.Interfaces
{
    public interface IEventPublisher
    {
        Task<long> PublishEvent<T>(string topic, BaseEvent<T> @event) where T : class;
    }
}
