using System;
using System.Threading.Tasks;
using CarService.AppCore.Interfaces;
using CarService.Domain.Models;
using MongoDB.Driver;

namespace CarService.Infrastructure.MongoDb.Repositories
{
    public abstract class BaseMongoDbRepository<T> : IBaseRepository<T> where T: IBaseModel
    {
        protected abstract IMongoCollection<T> Collection { get; }
        public Task<T> GetById(Guid id)
        {
            return Collection.Find(x => x.Id == id).FirstOrDefaultAsync();
        }
    }
}
