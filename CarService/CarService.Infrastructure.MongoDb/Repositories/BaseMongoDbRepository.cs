using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CarService.AppCore.Interfaces;
using CarService.Domain.Models;
using MongoDB.Bson;
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

        public Task<T> Create(T entity)
        {
            Collection.InsertOneAsync(entity);

            return Collection.Find(x => x.Id == entity.Id).FirstOrDefaultAsync();
        }

        public Task Delete(T entity)
        {
            return Collection.DeleteOneAsync(x => x.Id == entity.Id);
        }

        public Task<List<T>> GetAll()
        {
            return Collection.AsQueryable().ToListAsync();
        }

        public abstract Task Update(T entity);
    }
}
