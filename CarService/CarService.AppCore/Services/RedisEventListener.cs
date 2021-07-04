using System;
using System.Threading.Tasks;
using CarService.AppCore.Cqrs.Commands;
using CarService.AppCore.Interfaces;
using CarService.AppCore.Models.EventModels;
using CarService.AppCore.Models.Events;
using CarService.Domain.Models;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using StackExchange.Redis;

namespace CarService.AppCore.Services
{
    public class RedisEventListener: IEventListener, IDisposable
    {
        private readonly IMediator _mediator;
        private readonly ISubscriber _subscriber;

        public RedisEventListener(IConfiguration configuration, IMediator mediator)
        {
            _mediator = mediator;
            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(configuration.GetConnectionString("Redis"));
            _subscriber = redis.GetSubscriber();
            var channel = _subscriber.Subscribe("repairOrders");
            channel.OnMessage(OnRepairOrdersMessage);
        }

        private Task OnRepairOrdersMessage(ChannelMessage message)
        {
            var eventObject = JsonConvert.DeserializeObject<BaseEvent<RepairOrderRedisEventDataModel>>(message.Message);
            var eventType = Type.GetType(eventObject.Type);
            var eventDataModel = new RepairOrderRedisEventDataModel
            {
                Id = eventObject.Data.Id,
                CarId = eventObject.Data.CarId,
                OrderDate = eventObject.Data.OrderDate,
                Price = eventObject.Data.Price
            };

            if (eventObject == null || eventType == null)
            {
                return Task.CompletedTask;
            }

            var redisEventFactory = new RedisEventFactory();
            var redisEvent = redisEventFactory.CreateEvent<RepairOrderRedisEventDataModel>(eventType);

            var commandFactory = new CommandFactory();
            var command = commandFactory.CreateCommand(redisEvent, eventDataModel);

            return _mediator.Send(command);
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
