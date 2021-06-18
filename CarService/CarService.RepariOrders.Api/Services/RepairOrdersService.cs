using System;
using System.Threading.Tasks;
using CarService.RepariOrders.Api.Interfaces;
using CarService.RepariOrders.Api.Models.Domain;
using CarService.RepariOrders.Api.Models.Domain.Events;
using CarService.RepariOrders.Api.Models.Requests;

namespace CarService.RepariOrders.Api.Services
{
    public class RepairOrdersService : IRepairOrdersService
    {
        private readonly IRepairOrderRepository _repairOrderRepository;
        private readonly IEventPublisher _eventPublisher;

        public RepairOrdersService(IRepairOrderRepository repairOrderRepository, IEventPublisher eventPublisher)
        {
            _repairOrderRepository = repairOrderRepository;
            _eventPublisher = eventPublisher;
        }

        public async Task<RepairOrder> CreateRepairOrder(CreateRepairModelRequest order)
        {
            var repairOrder = new RepairOrder
            {
                Id = Guid.NewGuid(),
                Price = order.Price,
                CarId = order.CarId,
                OrderDate = order.OrderDate
            };

            await _repairOrderRepository.Create(repairOrder);

            await _eventPublisher.PublishEvent("repairOrders", new RepairOrderCreatedEvent
            {
                RepairOrderId = repairOrder.Id,
                Price = repairOrder.Price,
                CarId = repairOrder.CarId,
                OrderDate = repairOrder.OrderDate
            });


            return repairOrder;
        }

        public async Task<RepairOrder> GetRepairOrderByCarId(Guid carId)
        {
            return await _repairOrderRepository.GetByCarId(carId);
        }

        public async Task<RepairOrder> GetRepairOrderById(Guid id)
        {
            return await _repairOrderRepository.GetById(id);
        }

        public async Task UpdateRepairOrder(UpdateRepairOrderRequest order)
        {
            var model = new RepairOrder
            {
                Id = order.Id,
                Price = order.Price,
                OrderDate = order.OrderDate,
                CarId = order.CarId
            };

            await _repairOrderRepository.Update(model);
        }
    }
}
