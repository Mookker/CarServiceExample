using System.Threading.Tasks;
using CarService.AppCore.Models.Requests;
using CarService.Domain.Models;

namespace CarService.AppCore.Interfaces
{
    public interface IRepairOrdersService
    {
        public Task<RepairOrder> CreateAsync(CreateRepairOrderRequest request);
    }
}
