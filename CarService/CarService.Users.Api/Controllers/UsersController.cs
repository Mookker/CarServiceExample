using System.Threading.Tasks;
using AutoMapper;
using CarService.Users.Api.Cqrs.Commands;
using CarService.Users.Api.Cqrs.Queries;
using CarService.Users.Api.Models.Requests;
using CarService.Users.Api.Models.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarService.Users.Api.Controllers
{
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
    }
}
