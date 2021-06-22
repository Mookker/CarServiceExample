using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CarService.Domain.Models;

namespace CarService.AppCore.Interfaces
{
    public interface IBaseRepository<T> where T: IBaseModel
    {
        Task<T> GetById(Guid id);
        Task<List<T>> GetAll();
        Task<T> Create(T entity);
        Task Delete(Guid id);
        Task Update(T entity);
    }
}
