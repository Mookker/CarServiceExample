using System;
using System.Threading.Tasks;
using CarService.AppCore.Models.Requests;
using CarService.Domain.Models;

namespace CarService.AppCore.Interfaces
{
    public interface IRepairOrdersService
    {
        public Task<RepairOrder> GetById(Guid id);
        public Task<RepairOrder> GetByCarId(Guid carId);
        public Task<RepairOrder> CreateAsync(CreateRepairOrderRequest request);
        public Task DeleteAsync(Guid id);
        public Task UpdateAsync(UpdateRepairOrderRequest request);
    }
}
