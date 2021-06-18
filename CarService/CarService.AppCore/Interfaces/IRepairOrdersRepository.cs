using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CarService.Domain.Models;

namespace CarService.AppCore.Interfaces
{
    public interface IRepairOrdersRepository : IBaseRepository<RepairOrder>
    {
        Task<List<RepairOrder>> GetByCarId(Guid carId);
    }
}
