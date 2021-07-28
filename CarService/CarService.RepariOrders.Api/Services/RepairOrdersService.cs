using System;
using System.Threading.Tasks;
using CarService.AppCore.Interfaces;
using CarService.AppCore.Models.EventModels;
using CarService.AppCore.Models.Events;
using CarService.AppCore.Models.Requests;
using CarService.Domain.Models;
using CarService.RepariOrders.Api.Interfaces;

namespace CarService.RepariOrders.Api.Services
{
    public class RepairOrdersService : AppCore.Interfaces.IRepairOrdersService
    {
        private readonly IRepairOrderRepository _repairOrderRepository;
        private readonly IEventPublisher _eventPublisher;

        public RepairOrdersService(IRepairOrderRepository repairOrderRepository, IEventPublisher eventPublisher)
        {
            _repairOrderRepository = repairOrderRepository;
            _eventPublisher = eventPublisher;
        }

        public async Task<RepairOrder> CreateAsync(CreateRepairOrderRequest request)
        {
            var repairOrder = new RepairOrder
            {
                Id = Guid.NewGuid(),
                Price = request.Price,
                CarId = request.CarId,
                OrderDate = request.OrderDate
            };

            await _repairOrderRepository.Create(repairOrder);

            await _eventPublisher.PublishEvent("repairOrders", new RepairOrderCreatedEvent
            {
                Type = nameof(RepairOrderCreatedEvent),
                Data = new RepairOrderCreatedDataModel
                {
                    Id = repairOrder.Id,
                    CarId = repairOrder.CarId,
                    Price = repairOrder.Price,
                    OrderDate = repairOrder.OrderDate
                }
            });

            return repairOrder;
        }

        public async Task DeleteAsync(Guid id)
        {
            await _repairOrderRepository.Delete(id);

            await _eventPublisher.PublishEvent("repairOrders", new RepairOrderDeletedEvent
            {
                Type = nameof(RepairOrderDeletedEvent),
                Data = new RepairOrderDeletedDataModel { Id = id }
            });
        }

        public async Task<RepairOrder> GetByCarId(Guid carId)
        {
            var repairOrder = await _repairOrderRepository.GetByCarId(carId);

            return repairOrder;
        }

        public async Task<RepairOrder> GetById(Guid id)
        {
            var repairOrder = await _repairOrderRepository.GetById(id);

            return repairOrder;
        }

        public async Task UpdateAsync(UpdateRepairOrderRequest request)
        {
            var repairOrder = new RepairOrder
            {
                Id = request.Id,
                CarId = request.CarId,
                OrderDate = request.OrderDate,
                Price = request.Price
            };

            await _repairOrderRepository.Update(repairOrder);

            await _eventPublisher.PublishEvent("repairOrders", new RepairOrderUpdatedEvent
            {
                Type = nameof(RepairOrderUpdatedEvent),
                Data = new RepairOrderUpdatedDataModel
                {
                    Id = repairOrder.Id,
                    CarId = repairOrder.CarId,
                    Price = repairOrder.Price,
                    OrderDate = repairOrder.OrderDate
                }
            });
        }
    }
}
