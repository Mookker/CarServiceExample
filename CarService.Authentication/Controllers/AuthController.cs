using CarService.Authentication.Interfaces;
using CarService.Authentication.Models;
using CarService.Users.Api.Cqrs.Queries;
using CarService.Users.Api.Models.Domain;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CarService.Authentication.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly IMediator _mediator;

        public AuthController(
            IAuthenticationService authenticationService, 
            IPasswordHasher<User> passwordHasher, 
            IMediator mediator)
        {
            _authenticationService = authenticationService;
            _passwordHasher = passwordHasher;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AuthenticateUser([FromBody] LoginUserRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var userDto = await _mediator.Send(new GetUserByUsernameQuery { Username = request.Username });

            if (userDto == null)
            {
                return NotFound("User doesn't exist");
            }

            var user = new User
            {
                Id = userDto.Id,
                Username = userDto.Username,
                Password = userDto.Password,
                Roles = userDto.Roles,
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                DoB = userDto.DoB,
                CarId = userDto.CarId
            };

            var passwordVerificationResult = _passwordHasher.VerifyHashedPassword(user, user.Password, request.Password);

            if (user.Username != request.Username || passwordVerificationResult == PasswordVerificationResult.Failed)
            {
                return StatusCode(403, "Wrong username or password");
            }

            var response = _authenticationService.Authenticate(user);

            return Ok(response);
        }
    }
}
