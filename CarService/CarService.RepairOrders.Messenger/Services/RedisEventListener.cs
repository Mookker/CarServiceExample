using CarService.AppCore.Models.EventModels;
using CarService.AppCore.Models.Events;
using CarService.RepairOrders.Messenger.Interfaces;
using MediatR;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using StackExchange.Redis;
using System;
using System.Threading.Tasks;

namespace CarService.RepairOrders.Messenger.Services
{
    public class RedisEventListener : IEventListener, IDisposable
    {
        private readonly IMediator _mediator;
        private readonly ISubscriber _subscriber;
        private readonly ICommandFactory _commandFactory;

        public RedisEventListener(IConfiguration configuration, IMediator mediator, ICommandFactory commandFactory)
        {
            _mediator = mediator;
            _commandFactory = commandFactory;
            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(configuration.GetConnectionString("Redis"));
            _subscriber = redis.GetSubscriber();

            var channel = _subscriber.Subscribe("repairOrders");
            channel.OnMessage(OnRepairOrdersMessage);
        }

        private Task OnRepairOrdersMessage(ChannelMessage message)
        {
            var eventObject = JsonConvert.DeserializeObject<BaseEvent<JObject>>(message.Message);

            if (eventObject == null)
            {
                return Task.CompletedTask;
            }

            var command = _commandFactory.CreateCommand(eventObject);

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
