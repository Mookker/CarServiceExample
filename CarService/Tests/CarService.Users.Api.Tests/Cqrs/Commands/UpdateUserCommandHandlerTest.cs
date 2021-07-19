using CarService.Users.Api.Cqrs.Commands;
using CarService.Users.Api.Cqrs.Commands.Handlers;
using CarService.Users.Api.Interfaces;
using CarService.Users.Api.Models.Domain;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace CarService.Users.Api.Tests.Cqrs.Commands
{
    public class UpdateUserCommandHandlerTest
    {
        private readonly Mock<IUsersRepository> _usersRepository;
        private readonly UpdateUserCommandHandler _handler;

        public UpdateUserCommandHandlerTest()
        {
            _usersRepository = new Mock<IUsersRepository>();
            _handler = new UpdateUserCommandHandler(_usersRepository.Object);
        }

        [Fact]
        public async Task UpdateUserCommandHandler_Should_Handle_Command_And_Return_UserDto()
        {
            // Arrange
            var userId = Guid.NewGuid();
            var carId = Guid.NewGuid();
            const string TEST_NAME = "Test";
            var updatedUser = new User
            {
                Id = userId,
                CarId = carId,
                DoB = DateTime.MinValue,
                FirstName = TEST_NAME,
                LastName = TEST_NAME
            };

            _usersRepository.Setup(r => r.GetById(It.IsAny<Guid>())).ReturnsAsync(updatedUser);

            var command = new UpdateUserCommand(userId, TEST_NAME, TEST_NAME, DateTime.MinValue, carId);

            // Act
            var result = await _handler.Handle(command, default);

            // Assert
            Assert.True(result.CarId == command.CarId && result.DoB == command.DoB
                && result.FirstName == command.FirstName && result.LastName == command.LastName);
        }
    }
}
