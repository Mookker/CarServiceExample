using CarService.Authentication.Models;
using CarService.Users.Api.Models.Domain;

namespace CarService.Authentication.Interfaces
{
    public interface IAuthenticationService
    {
        TokenResponse Authenticate(User user);
    }
}
