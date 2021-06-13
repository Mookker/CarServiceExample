using System.Threading.Tasks;
using CarService.RepariOrders.Api.Models.Domain;

namespace CarService.RepariOrders.Api.Interfaces
{
    public interface IRepairOrderRepository
    {
        public Task Create(RepairOrder order);
    }
}
