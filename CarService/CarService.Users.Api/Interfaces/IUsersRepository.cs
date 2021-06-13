using System;
using System.Threading.Tasks;
using CarService.Users.Api.Models.Domain;

namespace CarService.Users.Api.Interfaces
{
    public interface IUsersRepository
    {
        Task<User> GetById(Guid userId);
        Task Create(User user);
    }
}
