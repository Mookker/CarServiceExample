using System;
using System.Threading.Tasks;
using CarService.AppCore.Models;
using CarService.AppCore.Models.Requests;
using CarService.Domain.Models;

namespace CarService.AppCore.Interfaces
{
    public interface IUsersService
    {
        Task<CarOwner> GetUserById(string userId);
        Task<CarOwner> GetUserByCarId(string carId);
        Task<CarOwner> CreateUser(CreateCarOwnerRequest request);
        Task UpdateUser(UpdateCarOwnerRequest request);
        Task DeleteUser(string userId);
    }
}
