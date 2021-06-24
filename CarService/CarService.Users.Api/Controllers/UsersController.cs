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
using System.Collections.Generic;
using CarService.Users.Api.Models.Dtos;

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
        public async Task<IActionResult> CreateUser([FromBody]CreateUserRequest model)
        {
            var dto = await _mediator.Send(new CreateUserCommand(model.FirstName, model.LastName, model.DoB, model.CarId));

            return Ok(_mapper.Map<UserResponse>(dto));
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers([FromQuery] Guid carId)
        {
            var dtoList = await _mediator.Send(new GetAllUsersQuery());
            IEnumerable<UserResponse> response;
            
            if (carId == Guid.Empty)
            {
                response = dtoList.Select(dto => _mapper.Map<UserResponse>(dto));
            }
            else
            {
                response = dtoList
                    .Select(dto => _mapper.Map<UserResponse>(dto))
                    .Where(dto => dto.CarId == carId);
            }

            return Ok(response);
        }

        [HttpDelete("{userId}")]
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
