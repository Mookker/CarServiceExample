using System;
using System.Threading.Tasks;
using CarService.AppCore.Interfaces;
using CarService.AppCore.Models.Events;
using CarService.Domain.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace CarService.AppCore.Services
{
    public class RedisEventListener: IEventListener, IDisposable
    {
        //private readonly IRepairOrdersRepository _repairOrdersRepository;
        private readonly ISubscriber _subscriber;
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public RedisEventListener(IConfiguration configuration, IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(configuration.GetConnectionString("Redis"));
            _subscriber = redis.GetSubscriber();
            var channel = _subscriber.Subscribe("repairOrders");
            channel.OnMessage(OnMessage);
        }

        private Task OnMessage(ChannelMessage message)
        {
            //TODO: something smart to resolve event
            var eventObject = JsonConvert.DeserializeObject<RepairOrderCreatedEvent>(message.Message);
            if (eventObject == null)
            {
                return Task.CompletedTask;
            }

            using var scope = _serviceScopeFactory.CreateScope();
            var repairOrdersRepository = scope.ServiceProvider.GetService<IRepairOrdersRepository>();


            return repairOrdersRepository.Create(new RepairOrder
            {
                Id = eventObject.RepairOrderId,
                Price = eventObject.Price,
                CarId = eventObject.CarId,
                OrderDate = eventObject.OrderDate
            });
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _subscriber.UnsubscribeAll();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
