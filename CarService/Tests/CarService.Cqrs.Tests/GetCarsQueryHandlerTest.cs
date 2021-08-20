using CarService.AppCore.Interfaces;
using CarService.Cqrs.Queries;
using CarService.Cqrs.Queries.Handlers;
using CarService.Domain.Models;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace CarService.Cqrs.Tests
{
    public class GetCarsQueryHandlerTest
    {
        private Mock<ICarsRepository> _repository;
        private GetCarsQueryHandler _handler;

        public GetCarsQueryHandlerTest()
        {
            _repository = new Mock<ICarsRepository>();
            _handler = new GetCarsQueryHandler(_repository.Object);
        }

        [Fact]
        public async Task Handler_Should_Handle_Request_And_Return_Cars()
        {
            // Arrange
            _repository.Setup(r => r.GetAll()).ReturnsAsync(GetCarsExample());

            // Act
            var result = await _handler.Handle(new GetCarsQuery(), default);

            // Assert
            Assert.Equal(3, result.Count());
        }

        private List<Car> GetCarsExample()
        {
            return new List<Car>
            {
                new Car(),
                new Car(),
                new Car(),
            };
        }
    }
}
