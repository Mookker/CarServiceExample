using AutoMapper;
using CarService.AppCore.Interfaces;
using CarService.AppCore.Models.Requests;
using CarService.Domain.Models;
using CarService.RepariOrders.Api.Controllers;
using CarService.RepariOrders.Api.MapperProfiles;
using CarService.RepariOrders.Api.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CarService.RepairOrders.Api.Tests
{
    public class RepairOrdersControllerTest
    {
        private readonly Mock<IRepairOrdersService> _service;
        private readonly IMapper _mapper;
        private readonly RepairOrdersController _controller;

        public RepairOrdersControllerTest()
        {
            _service = new Mock<IRepairOrdersService>();
            var mapperConfig = new MapperConfiguration(cfg => cfg.AddProfile<RepairOrderMapperProfile>());
            _mapper = mapperConfig.CreateMapper();
            _controller = new RepairOrdersController(_service.Object, _mapper);
        }

        [Fact]
        public async Task Controller_Should_Return_RepairOrderById()
        {
            // Arrange
            var id = Guid.Parse("a7e39df3-3fe4-4944-81f1-8c013687f8cb");
            _service.Setup(s => s.GetById(It.IsAny<Guid>())).ReturnsAsync(new RepairOrder { Id = id });

            // Act
            var result = await _controller.GetRepairOrderById(id);

            // Assert
            var resultObject = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<RepairOrderResponse>(resultObject.Value);
            Assert.Equal(id, model.Id);
        }
        
        [Fact]
        public async Task Controller_Should_Return_RepairOrderByCarId()
        {
            // Arrange
            var carId = Guid.Parse("a7e39df3-3fe4-4944-81f1-8c013687f8cb");
            _service.Setup(s => s.GetByCarId(It.IsAny<Guid>())).ReturnsAsync(new RepairOrder { CarId = carId });

            // Act
            var result = await _controller.GetRepairOrderByCarId(carId);

            // Assert
            var objectResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<RepairOrderResponse>(objectResult.Value);
            Assert.Equal(carId, model.CarId);
        }

        [Fact]
        public async Task Controller_Should_Return_BadRequest_When_CarId_IsEmpty()
        {
            // Arrange
            var carId = Guid.Empty;

            // Act
            var result = await _controller.GetRepairOrderByCarId(carId);

            // Assert
            Assert.IsType<BadRequestResult>(result);
        }
        
        [Fact]
        public async Task Controller_Should_Create_RepairOrder()
        {
            // Arrange
            var carId = Guid.Parse("a7e39df3-3fe4-4944-81f1-8c013687f8cb");
            var request = new CreateRepairOrderRequest { Price = 100, OrderDate = DateTime.MinValue, CarId = carId };
            var repairOrder = new RepairOrder
            {
                Id = Guid.Empty,
                CarId = request.CarId,
                Price = request.Price,
                OrderDate = request.OrderDate
            };

            _service.Setup(s => s.CreateAsync(It.IsAny<CreateRepairOrderRequest>())).ReturnsAsync(repairOrder);

            // Act
            var result = await _controller.CreateRepairOrder(request);

            // Assert
            var objectResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<RepairOrderResponse>(objectResult.Value);
            Assert.True(model.Price == request.Price && model.CarId == request.CarId && model.OrderDate == request.OrderDate);
        }

        [Fact]
        public async Task Controller_Should_Return_BadRequest_When_CreateRequest_IsNull()
        {
            // Act
            var result = await _controller.CreateRepairOrder(null);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task Controller_Should_Update_RepairOrder()
        {
            // Arrange
            var request = new UpdateRepairOrderRequest
            {
                Id = Guid.NewGuid(),
                CarId = Guid.NewGuid(),
                OrderDate = DateTime.MaxValue,
                Price = 100
            };

            var repairOrder = new RepairOrder
            {
                Id = Guid.Empty,
                CarId = Guid.Empty,
                Price = 0,
                OrderDate = DateTime.MinValue
            };

            _service.Setup(s => s.GetById(It.IsAny<Guid>())).ReturnsAsync(repairOrder);

            // Act
            var result = await _controller.UpdateRepairOrder(request);

            // Assert
            Assert.IsType<OkResult>(result);
        }
    }
}
