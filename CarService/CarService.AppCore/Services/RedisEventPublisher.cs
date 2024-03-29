using System.Threading.Tasks;
using CarService.AppCore.Interfaces;
using CarService.AppCore.Models.Events;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace CarService.AppCore.Services
{
    public class RedisEventPublisher: IEventPublisher
    {
        private readonly ISubscriber _publisher;

        public RedisEventPublisher(IConfiguration configuration)
        {
            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(configuration.GetConnectionString("Redis"));
            _publisher = redis.GetSubscriber();
        }

        public Task<long> PublishEvent<T>(string topic, BaseEvent<T> @event) where T : class
        {
            return _publisher.PublishAsync(topic, JsonConvert.SerializeObject(@event));
        }
    }
}
