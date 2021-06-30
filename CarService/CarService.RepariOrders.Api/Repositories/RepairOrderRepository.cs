using System;
using System.Threading.Tasks;
using CarService.Domain.Models;
using CarService.RepariOrders.Api.Interfaces;
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

        public Task Delete(Guid id)
        {
            var ID = new { Id = id };
            string query = $@"DELETE FROM ""repairOrders"" WHERE ""Id"" = @Id";

            return _dapper.ExecuteAsync(query, ID);
        }

        public Task<RepairOrder> GetByCarId(Guid carId)
        {
            var ID = new { CarId = carId };
            string query = $@"SELECT * FROM ""repairOrders"" WHERE ""CarId"" = @CarId";

            return _dapper.QueryFirstOrDefaultAsync<RepairOrder>(query, ID);
        }

        public Task<RepairOrder> GetById(Guid id)
        {
            var ID = new { Id = id };
            string query = $@"SELECT * FROM ""repairOrders"" WHERE ""Id"" = @Id";

            return _dapper.QueryFirstOrDefaultAsync<RepairOrder>(query, ID);
        }

        public Task Update(RepairOrder order)
        {
            string query = @"UPDATE ""repairOrders"" SET 
                           ""Price"" = @Price, 
                           ""CarId"" = @CarId, 
                           ""OrderDate"" = @OrderDate
                             WHERE ""Id"" = @Id";

            return _dapper.ExecuteAsync(query, order);
        }
    }
}
