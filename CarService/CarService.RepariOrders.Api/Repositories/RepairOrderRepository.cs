using System.Threading.Tasks;
using CarService.RepariOrders.Api.Interfaces;
using CarService.RepariOrders.Api.Models.Domain;
using Dapper.Extensions;

namespace CarService.RepariOrders.Api.Repositories
{
    public class RepairOrderRepository: IRepairOrderRepository
    {
        private readonly IDapper _dapper;

        public RepairOrderRepository(IDapper dapper)
        {
            _dapper = dapper;
        }
        public Task Create(RepairOrder order)
        {
            return _dapper.ExecuteAsync(
                @"INSERT INTO ""repairOrders"" (""Id"", ""Price"", ""OrderDate"", ""CarId"") VALUES (@Id, @Price, @OrderDate, @CarId)",
                order);
        }
    }
}
