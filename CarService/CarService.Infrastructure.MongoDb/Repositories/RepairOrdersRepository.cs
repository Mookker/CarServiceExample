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

        public Task Create(RepairOrder repairOrder)
        {
            return Collection.InsertOneAsync(repairOrder);
        }
    }
}
