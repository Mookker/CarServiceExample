using System;
using System.Threading.Tasks;
using System.Linq;
using AutoMapper;
using CarService.Users.Api.Cqrs.Commands;
using CarService.Users.Api.Cqrs.Queries;
using CarService.Users.Api.Models.Requests;
using CarService.Users.Api.Models.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarService.Users.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UsersController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public UsersController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserById(string userId)
        {
            var dto = await _mediator.Send(new GetUserByIdQuery(userId));

            return Ok(_mapper.Map<UserResponse>(dto));
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody]CreateUserRequest model)
        {
            var dto = await _mediator.Send(new CreateUserCommand(model.FirstName, model.LastName, model.DoB, model.CarId));

            return Ok(_mapper.Map<UserResponse>(dto));
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers([FromQuery] string carId)
        {
            var dtoList = await _mediator.Send(new GetAllUsersQuery());

            var response = dtoList.Select(dto => _mapper.Map<UserResponse>(dto));

            if (!string.IsNullOrEmpty(carId))
            {
                response = response.Where(c => c.CarId == carId).ToList();
            }

            return Ok(response);
        }

        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteUser(string userId)
        {
            var dto = await _mediator.Send(new DeleteUserCommand(Guid.Parse(userId)));

            var response = _mapper.Map<UserResponse>(dto);

            return Ok(response);
        }

        [HttpPut("{userId}")]
        public async Task<IActionResult> UpdateUser(string userId, [FromBody] UpdateUserRequest request)
        {
            var dto = await _mediator.Send(new UpdateUserCommand(
                Guid.Parse(userId), request.FirstName, request.LastName, request.DoB, request.CarId));

            var response = _mapper.Map<UserResponse>(dto);

            return Ok(response);
        }
    }
}
