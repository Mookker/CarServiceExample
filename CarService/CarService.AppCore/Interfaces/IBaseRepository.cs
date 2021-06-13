using System;
using System.Threading.Tasks;
using CarService.Domain.Models;

namespace CarService.AppCore.Interfaces
{
    public interface IBaseRepository<T> where T: IBaseModel
    {
        Task<T> GetById(Guid id);
    }
}
