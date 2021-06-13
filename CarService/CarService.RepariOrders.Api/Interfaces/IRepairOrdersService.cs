using System.Threading.Tasks;
using CarService.RepariOrders.Api.Models.Domain;
using CarService.RepariOrders.Api.Models.Requests;

namespace CarService.RepariOrders.Api.Interfaces
{
    public interface IRepairOrdersService
    {
        public Task<RepairOrder> CreateRepairOrder(CreateRepairModelRequest order);
    }
}
