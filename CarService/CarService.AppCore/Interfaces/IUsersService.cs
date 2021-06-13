using System.Threading.Tasks;
using CarService.AppCore.Models;
using CarService.AppCore.Models.Requests;
using CarService.Domain.Models;

namespace CarService.AppCore.Interfaces
{
    public interface IUsersService
    {
        public Task<CarOwner> GetUserById(string userId);
        Task<CarOwner> CreateUser(CreateCarOwnerRequest request);
    }
}
