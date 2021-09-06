using AutoMapper;
using CarService.Users.Api.Cqrs.Commands;
using CarService.Users.Api.Cqrs.Queries;
using CarService.Users.Api.Models.Dtos;
using CarService.Users.Api.Models.Requests;
using CarService.Users.Api.Models.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public async Task<IActionResult> GetUserById(Guid userId)
        {
            if (userId == Guid.Empty)
            {
                return BadRequest("Invalid User id");
            }

            var dto = await _mediator.Send(new GetUserByIdQuery(userId.ToString()));

            if (dto == null)
            {
                return NotFound("User is not found");
            }

            var response = _mapper.Map<UserResponse>(dto);

            return Ok(response);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateUser([FromBody]CreateUserRequest model)
        {
            var dto = await _mediator.Send(new CreateUserCommand(model.FirstName, model.LastName, model.DoB, model.CarId));

            return Ok(_mapper.Map<UserResponse>(dto));
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers([FromQuery] Guid carId, [FromQuery] string username = null)
        {
            if (carId == Guid.Empty && string.IsNullOrWhiteSpace(username))
            {
                var userDtos = await _mediator.Send(new GetAllUsersQuery());
                var usersResponse = userDtos.Select(dto => _mapper.Map<UserDto, UserResponse>(dto));

                return Ok(usersResponse);
            }
            else if (!string.IsNullOrWhiteSpace(username))
            {
                var userDto = await _mediator.Send(new GetUserByUsernameQuery() { Username = username });

                if (userDto == null)
                {
                    return NotFound("User doesn't exist");
                }

                return Ok(_mapper.Map<UserDto, UserResponse>(userDto));
            }
            else
            {
                var userDto = await _mediator.Send(new GetUserByCarIdQuery(carId));

                return Ok(_mapper.Map<UserDto, UserResponse>(userDto));
            }
        }

        [HttpDelete("{userId}")]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<IActionResult> DeleteUser(Guid userId)
        {
            if (userId == Guid.Empty)
            {
                return BadRequest("Invalid User id");
            }

            await _mediator.Send(new DeleteUserCommand(userId));

            return Ok();
        }

        [HttpPut("{userId}")]
        public async Task<IActionResult> UpdateUser(Guid userId, [FromBody] UpdateUserRequest request)
        {
            if (userId == Guid.Empty)
            {
                return BadRequest("Invalid User id");
            }

            if (request == null)
            {
                return BadRequest("Invalid body request");
            }

            var dto = await _mediator.Send(new UpdateUserCommand(
                userId, request.FirstName, request.LastName, request.DoB, request.CarId));

            var response = _mapper.Map<UserResponse>(dto);

            return Ok(response);
        }
    }
}
