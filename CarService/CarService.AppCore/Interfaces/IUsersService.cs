using CarService.AppCore.Models.Requests;
using CarService.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarService.AppCore.Interfaces
{
    public interface IUsersService
    {
        Task<IEnumerable<CarOwner>> GetUsers();
        Task<CarOwner> GetUserById(string userId);
        Task<CarOwner> GetUserByCarId(string carId);
        Task<CarOwner> CreateUser(CreateCarOwnerRequest request);
        Task UpdateUser(UpdateCarOwnerRequest request);
        Task DeleteUser(string userId);
    }
}
