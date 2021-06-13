using CarService.AppCore.Interfaces;
using CarService.Domain.Models;
using MongoDB.Driver;

namespace CarService.Infrastructure.MongoDb.Repositories
{
    public class CarsRepository : BaseMongoDbRepository<Car>, ICarsRepository
    {
        private readonly IMongoDatabase _db;
        protected override IMongoCollection<Car> Collection => _db.GetCollection<Car>("cars");
        public CarsRepository(IMongoClient mongoClient)
        {
            _db = mongoClient.GetDatabase("carService");
        }

    }
}
