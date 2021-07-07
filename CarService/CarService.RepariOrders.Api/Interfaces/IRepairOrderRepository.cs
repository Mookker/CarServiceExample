using System;
using System.Threading.Tasks;
using CarService.Domain.Models;

namespace CarService.RepariOrders.Api.Interfaces
{
    public interface IRepairOrderRepository
    {
        public Task Create(RepairOrder order);
        public Task<RepairOrder> GetById(Guid id);
        public Task<RepairOrder> GetByCarId(Guid carId);
        public Task Delete(Guid id);
        public Task Update(RepairOrder order);
    }
}
