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
    public class GetCarRepairOrdersQueryHandlerTest
    {
        private readonly Mock<IRepairOrdersRepository> _repository;
        private readonly GetCarRepairOrdersQueryHandler _handler;

        public GetCarRepairOrdersQueryHandlerTest()
        {
            _repository = new Mock<IRepairOrdersRepository>();
            _handler = new GetCarRepairOrdersQueryHandler(_repository.Object);
        }

        [Fact]
        public async Task Handelr_Should_Handle_GetCarRepairOrdersQuery_And_Return_CarRepairOrders()
        {
            // Arrange
            var repairOrders = new List<RepairOrder>
            {
                new() {Price = 0},
                new() {Price = 1},
                new() {Price = 2},
            };

            var query = new GetCarRepairOrdersQuery(Guid.Empty);

            _repository.Setup(r => r.GetByCarId(It.IsAny<Guid>())).ReturnsAsync(repairOrders);

            // Act
            var models = await _handler.Handle(query, default);

            // Assert
            Assert.Equal(repairOrders, models);
        }
    }
}
