using CarService.AppCore.Interfaces;
using CarService.AppCore.Models.Requests;
using CarService.Domain.Models;
using CarService.RepariOrders.Api.Interfaces;
using CarService.RepariOrders.Api.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CarService.RepairOrders.Api.Tests
{
    public class RepairOrdersServiceTest
    {
        private readonly Mock<IRepairOrderRepository> _repository;
        private readonly Mock<IEventPublisher> _eventPublisher;
        private readonly RepairOrdersService _service;

        public RepairOrdersServiceTest()
        {
            _repository = new Mock<IRepairOrderRepository>();
            _eventPublisher = new Mock<IEventPublisher>();
            _service = new RepairOrdersService(_repository.Object, _eventPublisher.Object);
        }

        [Fact]
        public async Task Service_Should_Create_And_Return_RepairOrder()
        {
            // Arrange
            var request = new CreateRepairOrderRequest
            {
                Id = Guid.Empty,
                CarId = Guid.Empty,
                OrderDate = DateTime.MinValue,
                Price = 100
            };

            // Act
            var model = await _service.CreateAsync(request);

            // Assert
            Assert.True(request.Id == model.Id && request.CarId == model.CarId 
                && request.OrderDate == model.OrderDate && request.Price == model.Price);
        }

        [Fact]
        public async Task Service_Should_Return_RepairOrderById()
        {
            // Arrange
            var repairOrder = new RepairOrder
            {
                Id = Guid.Empty,
                CarId = Guid.Empty,
                OrderDate = DateTime.MinValue,
                Price = 100
            };

            _repository.Setup(r => r.GetById(It.IsAny<Guid>())).ReturnsAsync(repairOrder);

            // Act
            var model = await _service.GetById(Guid.Empty);

            // Assert
            Assert.True(repairOrder.Id == model.Id && repairOrder.CarId == model.CarId
                && repairOrder.OrderDate == model.OrderDate && repairOrder.Price == model.Price);
        }

        [Fact]
        public async Task Service_Should_Return_RepairOrderByCarId()
        {
            // Arrange
            var repairOrder = new RepairOrder
            {
                Id = Guid.Empty,
                CarId = Guid.Empty,
                OrderDate = DateTime.MinValue,
                Price = 100
            };

            _repository.Setup(r => r.GetByCarId(It.IsAny<Guid>())).ReturnsAsync(repairOrder);

            // Act
            var model = await _service.GetByCarId(Guid.Empty);

            // Assert
            Assert.True(repairOrder.Id == model.Id && repairOrder.CarId == model.CarId
                && repairOrder.OrderDate == model.OrderDate && repairOrder.Price == model.Price);
        }
    }
}
