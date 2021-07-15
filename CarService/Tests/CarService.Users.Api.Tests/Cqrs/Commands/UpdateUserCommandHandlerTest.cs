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
            var updatedUser = new User
            {
                Id = Guid.Parse("b699d106-70ef-4b42-9353-fec5ee1f43cd"),
                CarId = Guid.Parse("b699d106-70ef-4b42-9353-fec5ee1f43cd"),
                DoB = DateTime.MinValue,
                FirstName = "Test",
                LastName = "Test"
            };

            _usersRepository.Setup(r => r.GetById(It.IsAny<Guid>())).ReturnsAsync(updatedUser);

            var command = new UpdateUserCommand(Guid.Parse("b699d106-70ef-4b42-9353-fec5ee1f43cd"), "Test", 
                "Test", DateTime.MinValue, Guid.Parse("b699d106-70ef-4b42-9353-fec5ee1f43cd"));

            // Act
            var result = await _handler.Handle(command, default);

            // Assert
            Assert.True(result.CarId == command.CarId && result.DoB == command.DoB
                && result.FirstName == command.FirstName && result.LastName == command.LastName);
        }
    }
}
