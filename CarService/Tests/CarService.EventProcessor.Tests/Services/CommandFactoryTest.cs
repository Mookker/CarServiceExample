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
            string jsonData = @"{
                                 'Type': 'RepairOrderCreatedEvent', 
                                 'Data': {
                                     'id' : 'ac307cca-0430-49b4-bbbf-dc59c8cbb177',
                                     'price' : 100,
                                     'orderDate' : '2021-06-17T00:00:00.000Z',
                                     'carId' : '35992974-21ea-4f61-b715-2dfaed663b73'
                                  }
                                }";

            var @event = JsonConvert.DeserializeObject<BaseEvent<JObject>>(jsonData);

            // Act
            var command = _factory.CreateCommand(@event);

            // Assert
            Assert.NotNull(command);
            Assert.IsAssignableFrom<CreateRepairOrderCommand>(command);
        }

        [Fact]
        public void Factory_Should_Return_DeleteRepairOrderCommand()
        {
            // Arrange
            string jsonData = @"{
                                 'Type': 'RepairOrderDeletedEvent', 
                                 'Data': {'id' : 'ac307cca-0430-49b4-bbbf-dc59c8cbb177'}
                                }";

            var @event = JsonConvert.DeserializeObject<BaseEvent<JObject>>(jsonData);

            // Act
            var command = _factory.CreateCommand(@event);

            // Assert
            Assert.NotNull(command);
            Assert.IsAssignableFrom<DeleteRepairOrderCommand>(command);
        }

        [Fact]
        public void Factory_Should_Return_UpdateRepairOrderCommand()
        {
            // Arrange
            string jsonData = @"{
                                 'Type': 'RepairOrderUpdatedEvent', 
                                 'Data': {
                                     'id' : 'ac307cca-0430-49b4-bbbf-dc59c8cbb177',
                                     'price' : 100,
                                     'orderDate' : '2021-06-17T00:00:00.000Z',
                                     'carId' : '35992974-21ea-4f61-b715-2dfaed663b73'
                                  }
                                }";

            var @event = JsonConvert.DeserializeObject<BaseEvent<JObject>>(jsonData);

            // Act
            var command = _factory.CreateCommand(@event);

            // Assert
            Assert.NotNull(command);
            Assert.IsAssignableFrom<UpdateRepairOrderCommand>(command);
        }
    }
}
