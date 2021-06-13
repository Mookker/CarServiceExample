using System.Threading.Tasks;
using CarService.RepariOrders.Api.Interfaces;
using CarService.RepariOrders.Api.Models.Domain.Events;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace CarService.RepariOrders.Api.Services
{
    public class EventPublisher: IEventPublisher
    {
        private readonly ISubscriber _publisher;

        public EventPublisher(IConfiguration configuration)
        {
            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(configuration.GetConnectionString("Redis"));
            _publisher = redis.GetSubscriber();
        }

        public Task PublishEvent<T>(string topic, T @event) where T: BaseEvent
        {
            return _publisher.PublishAsync(topic, JsonConvert.SerializeObject(@event));
        }
    }
}
