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
    public class CreateCarOwnerCommandHandlerTest
    {
        private readonly Mock<IUsersService> _service;
        private readonly CreateCarOwnerCommandHandler _handler;

        public CreateCarOwnerCommandHandlerTest()
        {
            _service = new Mock<IUsersService>();
            _handler = new CreateCarOwnerCommandHandler(_service.Object);
        }

        [Fact]
        public async Task Handler_Should_Handle_CreteCarOwnerCommand_And_Return_CreatedCarOwner()
        {
            // Arrange
            var carOwner = new CarOwner
            {
                Id = default,
                CarId = default,
                DoB = default,
                FirstName = "test",
                LastName = "test"
            };

            var command = new CreateCarOwnerCommand(carOwner);

            _service.Setup(s => s.CreateUser(It.IsAny<CreateCarOwnerRequest>())).ReturnsAsync(carOwner);

            // Act
            var model = await _handler.Handle(command, default);

            // Assert
            Assert.Equal(carOwner, model);
        }
    }
}
