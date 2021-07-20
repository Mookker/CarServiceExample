using CarService.AppCore.Interfaces;
using CarService.AppCore.Models.Requests;
using CarService.Cqrs.Commands;
using CarService.Cqrs.Commands.Handlers;
using CarService.Domain.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CarService.Cqrs.Tests
{
    public class CreateRepairOrderCommandHandlerTest
    {
        private readonly Mock<IRepairOrdersService> _repository;
        private readonly CreateRepairOrderCommandHandler _handler;

        public CreateRepairOrderCommandHandlerTest()
        {
            _repository = new Mock<IRepairOrdersService>();
            _handler = new CreateRepairOrderCommandHandler(_repository.Object);
        }

        [Fact]
        public async Task Handler_Should_Handle_CreateRepairOrderCommand_And_Return_CreatedRepairOrder()
        {
            // Arrange
            var repairOrder = new RepairOrder
            {
                Id = default,
                CarId = default,
                Price = 0,
                OrderDate = default
            };

            var command = new CreateRepairOrderCommand(repairOrder);

            _repository.Setup(r => r.CreateAsync(It.IsAny<CreateRepairOrderRequest>())).ReturnsAsync(repairOrder);

            // Act
            var model = await _handler.Handle(command, default);

            // Assert
            Assert.Equal(repairOrder, model);
        }
    }
}
