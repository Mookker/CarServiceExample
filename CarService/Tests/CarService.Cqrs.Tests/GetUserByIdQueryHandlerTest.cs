using CarService.AppCore.Interfaces;
using CarService.Cqrs.Queries;
using CarService.Cqrs.Queries.Handlers;
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
    public class GetUserByIdQueryHandlerTest
    {
        private readonly Mock<IUsersService> _service;
        private readonly GetUserByIdQueryHandler _handler;

        public GetUserByIdQueryHandlerTest()
        {
            _service = new Mock<IUsersService>();
            _handler = new GetUserByIdQueryHandler(_service.Object);
        }

        [Fact]
        public async Task Handler_Should_Handle_GetUserByIdQuery_And_Return_UserById()
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

            var query = new GetUserByIdQuery(string.Empty);

            _service.Setup(s => s.GetUserById(It.IsAny<string>())).ReturnsAsync(carOwner);

            // Act
            var model = await _handler.Handle(query, default);

            // Assert
            Assert.Equal(carOwner, model);
        }
    }
}
