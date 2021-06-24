using System;
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

        public Task Delete(RepairOrder order)
        {
            string query = $@"DELETE FROM repairOrders WHERE ""Id"" = '{order.Id}'";

            return _dapper.ExecuteAsync(query);
        }

        public Task<RepairOrder> GetByCarId(Guid carId)
        {
            string query = $@"SELECT * FROM repairOrders WHERE ""CarId"" = '{carId}'";

            return _dapper.QueryFirstOrDefaultAsync<RepairOrder>(query);
        }

        public Task<RepairOrder> GetById(Guid id)
        {
            string query = $@"SELECT * FROM repairOrders WHERE ""Id"" = '{id}'";

            return _dapper.QueryFirstOrDefaultAsync<RepairOrder>(query);
        }

        public Task Update(RepairOrder order)
        {
            string query = @"UPDATE repairOrders SET 
                           ""Price"" = @Price, 
                           ""CarId"" = @CarId, 
                           ""OrderDate"" = @OrderDate, 
                             WHERE ""Id"" = @Id";

            return _dapper.ExecuteAsync(query);
        }
    }
}
