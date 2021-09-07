using System;
using System.Threading.Tasks;
using CarService.Users.Api.Models.Domain;
using System.Collections.Generic;

namespace CarService.Users.Api.Interfaces
{
    public interface IUsersRepository
    {
        Task<User> GetById(Guid userId);
        Task<List<User>> GetAll();
        Task Create(User user);
        Task Update(User user);
        Task Delete(Guid userId);
        Task<User> GetByCarId(Guid carId);
        Task<User> GetByUsername(string username);
    }
}
