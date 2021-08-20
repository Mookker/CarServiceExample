using CarService.AppCore.Interfaces;
using CarService.Cqrs.Queries;
using CarService.Cqrs.Queries.Handlers;
using CarService.Domain.Models;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace CarService.Cqrs.Tests
{
    public class GetCarByIdQueryHandlerTest
    {
        private readonly Mock<ICarsRepository> _repository;
        private readonly GetCarByIdQueryHandler _handler;

        public GetCarByIdQueryHandlerTest()
        {
            _repository = new Mock<ICarsRepository>();
            _handler = new GetCarByIdQueryHandler(_repository.Object);
        }

        [Fact]
        public async Task Handler_Should_Handler_GetCarQuery_And_Return_CarById()
        {
            // Arrange
            var car = new Car
            {
                Id = default,
                Make = default,
                Millage = 0,
                Model = default,
                OwnerId = default,
                Vin = default,
                Year = default
            };

            var query = new GetCarByIdQuery(Guid.Empty);

            _repository.Setup(r => r.GetById(It.IsAny<Guid>())).ReturnsAsync(car);

            // Act
            var model = await _handler.Handle(query, default);

            // Assert
            Assert.Equal(car, model);
        }
    }
}
