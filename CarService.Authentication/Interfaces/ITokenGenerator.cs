using CarService.Users.Api.Models.Domain;
using System.IdentityModel.Tokens.Jwt;

namespace CarService.Authentication.Interfaces
{
    public interface ITokenGenerator
    {
        JwtSecurityToken GenerateToken(User user);
    }
}
