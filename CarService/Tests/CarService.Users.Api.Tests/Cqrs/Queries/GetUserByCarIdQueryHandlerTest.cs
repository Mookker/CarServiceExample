using CarService.Users.Api.Cqrs.Queries;
using CarService.Users.Api.Cqrs.Queries.Handlers;
using CarService.Users.Api.Interfaces;
using CarService.Users.Api.Models.Domain;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CarService.Users.Api.Tests.Cqrs.Queries
{
    public class GetUserByCarIdQueryHandlerTest
    {
        private readonly Mock<IUsersRepository> _repository;
        private readonly GetUserByCarIdQueryHandler _handler;

        public GetUserByCarIdQueryHandlerTest()
        {
            _repository = new Mock<IUsersRepository>();
            _handler = new GetUserByCarIdQueryHandler(_repository.Object);
        }

        [Fact]
        public async Task Handler_Should_Handle_Query_And_Return_UserByCarId()
        {
            // Arrange
            var carId = Guid.NewGuid();
            _repository.Setup(r => r.GetByCarId(It.IsAny<Guid>())).ReturnsAsync(new User { CarId = carId });

            // Act
            var user = await _handler.Handle(new GetUserByCarIdQuery(carId), default);

            // Assert
            Assert.Equal(carId, user.CarId);
        }
    }
}
