using System;
using System.Threading.Tasks;
using CarService.RepariOrders.Api.Models.Domain;

namespace CarService.RepariOrders.Api.Interfaces
{
    public interface IRepairOrderRepository
    {
        public Task Create(RepairOrder order);
        public Task<RepairOrder> GetById(Guid id);
        public Task<RepairOrder> GetByCarId(Guid carId);
        public Task Delete(RepairOrder order);
        public Task Update(RepairOrder order);
    }
}
