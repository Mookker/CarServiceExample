using CarService.AppCore.Models.EventModels;
using CarService.AppCore.Models.Events;
using CarService.EventProcessor.Cqrs.Commands;
using CarService.EventProcessor.Interfaces;
using CarService.EventProcessor.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CarService.EventProcessor.Tests.Services
{
    public class CommandFactoryTest
    {
        private readonly ICommandFactory _factory;

        public CommandFactoryTest()
        {
            _factory = new CommandFactory();
        }

        [Fact]
        public void Factory_Should_Return_CreateRepairOrderCommand()
        {
            // Arrange
            var @event = new RepairOrderCreatedEvent
            {
                Type = nameof(RepairOrderCreatedEvent),
                Data = new RepairOrderCreatedDataModel
                {
                    Id = default,
                    CarId = default,
                    OrderDate = default,
                    Price = 0
                }
            };

            string jsonData = JsonConvert.SerializeObject(@event);

            var deserializedEvent = JsonConvert.DeserializeObject<BaseEvent<JObject>>(jsonData);

            // Act
            var command = _factory.CreateCommand(deserializedEvent);

            // Assert
            Assert.NotNull(command);
            Assert.IsAssignableFrom<CreateRepairOrderCommand>(command);
        }

        [Fact]
        public void Factory_Should_Return_DeleteRepairOrderCommand()
        {
            // Arrange
            var @event = new RepairOrderDeletedEvent
            {
                Type = nameof(RepairOrderDeletedEvent),
                Data = new RepairOrderDeletedDataModel { Id = default }
            };

            string jsonData = JsonConvert.SerializeObject(@event);

            var deserializedEvent = JsonConvert.DeserializeObject<BaseEvent<JObject>>(jsonData);

            // Act
            var command = _factory.CreateCommand(deserializedEvent);

            // Assert
            Assert.NotNull(command);
            Assert.IsAssignableFrom<DeleteRepairOrderCommand>(command);
        }

        [Fact]
        public void Factory_Should_Return_UpdateRepairOrderCommand()
        {
            // Arrange
            var @event = new RepairOrderUpdatedEvent
            {
                Type = nameof(RepairOrderUpdatedEvent),
                Data = new RepairOrderUpdatedDataModel
                {
                    Id = default,
                    CarId = default,
                    OrderDate = default,
                    Price = 0
                }
            };

            string jsonData = JsonConvert.SerializeObject(@event);

            var deserializedEvent = JsonConvert.DeserializeObject<BaseEvent<JObject>>(jsonData);

            // Act
            var command = _factory.CreateCommand(deserializedEvent);

            // Assert
            Assert.NotNull(command);
            Assert.IsAssignableFrom<UpdateRepairOrderCommand>(command);
        }
    }
}
