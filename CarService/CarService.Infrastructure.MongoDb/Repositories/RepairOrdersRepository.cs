using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CarService.AppCore.Interfaces;
using CarService.Domain.Models;
using MongoDB.Driver;

namespace CarService.Infrastructure.MongoDb.Repositories
{
    public class RepairOrdersRepository: BaseMongoDbRepository<RepairOrder>, IRepairOrdersRepository
    {
        private readonly IMongoDatabase _db;
        protected override IMongoCollection<RepairOrder> Collection => _db.GetCollection<RepairOrder>("repairOrders");
        public RepairOrdersRepository(IMongoClient mongoClient)
        {
            _db = mongoClient.GetDatabase("carService");
        }

        public Task<List<RepairOrder>> GetByCarId(Guid carId)
        {
            return Collection.Find(x => x.CarId == carId).ToListAsync();
        }

        public override Task Update(RepairOrder repairOrder)
        {
            var update = Builders<RepairOrder>.Update
                .Set(o => o.Price, repairOrder.Price)
                .Set(o => o.OrderDate, repairOrder.OrderDate)
                .Set(o => o.CarId, repairOrder.CarId);

            return Collection.UpdateOneAsync(o => o.Id == repairOrder.Id, update);
        }
    }
}
