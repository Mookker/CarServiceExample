using System;
using System.Threading.Tasks;
using CarService.AppCore.Cqrs.Commands;
using CarService.AppCore.Interfaces;
using CarService.AppCore.Models.Events;
using CarService.Domain.Models;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
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
            channel.OnMessage(OnMessage);
        }

        private Task OnMessage(ChannelMessage message)
        {
            var eventObject = JsonConvert.DeserializeObject<BaseEvent<RepairOrder>>(message.Message);
            var eventType = Type.GetType(eventObject.Type);
            var repairOrder = eventObject.Data;

            if (eventObject == null || eventType == null)
            {
                return Task.CompletedTask;
            }

            var redisEventFactory = new RedisEventFactory();
            var redisEvent = redisEventFactory.CreateEvent(eventType);

            object command = null;

            switch (redisEvent)
            {
                case RepairOrderCreatedEvent:
                    command = new CreateRepairOrderCommand
                    {
                        Id = repairOrder.Id,
                        Price = repairOrder.Price,
                        CarId = repairOrder.CarId,
                        OrderDate = repairOrder.OrderDate
                    };
                    break;

                case RepairOrderUpdatedEvent:
                    command = new UpdateRepairOrderCommand
                    {
                        Id = repairOrder.Id,
                        CarId = repairOrder.CarId,
                        OrderDate = repairOrder.OrderDate,
                        Price = repairOrder.Price
                    };
                    break;

                case RepairOrderDeletedEvent:
                    command = new DeleteRepairOrderCommand { Id = repairOrder.Id };
                    break;

                default:
                    break;
            }

            if (command == null)
            {
                return Task.CompletedTask;
            }

            var response = _mediator.Send(command);

            return response;
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
