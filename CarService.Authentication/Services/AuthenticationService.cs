using CarService.Authentication.Interfaces;
using CarService.Authentication.Models;
using CarService.Users.Api.Models.Domain;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace CarService.Authentication.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly ITokenGenerator _tokenGenerator;

        public AuthenticationService(ITokenGenerator tokenGenerator)
        {
            _tokenGenerator = tokenGenerator;
        }

        public TokenResponse Authenticate(User user)
        {
            var token = _tokenGenerator.GenerateToken(user);
            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return new TokenResponse
            {
                UserId = user.Id,
                ExpiresIn = token.ValidTo,
                Token = tokenString
            };
        }
    }
}
