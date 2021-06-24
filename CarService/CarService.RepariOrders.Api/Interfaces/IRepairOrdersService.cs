using System;
using System.Threading.Tasks;
using CarService.RepariOrders.Api.Models.Domain;
using CarService.RepariOrders.Api.Models.Requests;

namespace CarService.RepariOrders.Api.Interfaces
{
    public interface IRepairOrdersService
    {
        public Task<RepairOrder> CreateRepairOrder(CreateRepairModelRequest order);
        public Task<RepairOrder> GetRepairOrderById(Guid id);
        public Task<RepairOrder> GetRepairOrderByCarId(Guid carId);
        public Task UpdateRepairOrder(UpdateRepairOrderRequest order);
    }
}
