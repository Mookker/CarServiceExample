using CarService.Authentication.Interfaces;
using CarService.Authentication.Models;
using CarService.Users.Api.Cqrs.Queries;
using CarService.Users.Api.Models.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CarService.Authentication.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IMediator _mediator;

        public AuthController(IAuthenticationService authenticationService, IMediator mediator)
        {
            _authenticationService = authenticationService;
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

            if (userDto.Password != request.Password)
            {
                return Forbid("Wrong password");
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

            var response = _authenticationService.Authenticate(user);

            return Ok(response);
        }
    }
}
