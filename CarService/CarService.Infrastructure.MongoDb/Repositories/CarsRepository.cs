using CarService.AppCore.Interfaces;
using CarService.Domain.Models;
using MongoDB.Driver;
using System.Threading.Tasks;

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

        public override Task Update(Car car)
        {
            var update = Builders<Car>.Update
                .Set(c => c.Make, car.Make)
                .Set(c => c.Model, car.Model)
                .Set(c => c.Year, car.Year)
                .Set(c => c.Millage, car.Millage)
                .Set(c => c.OwnerId, car.OwnerId);

            return Collection.UpdateOneAsync(c => c.Id == car.Id, update);
        }
    }
}
