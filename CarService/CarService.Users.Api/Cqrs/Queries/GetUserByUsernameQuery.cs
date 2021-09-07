using CarService.Users.Api.Models.Dtos;
using MediatR;

namespace CarService.Users.Api.Cqrs.Queries
{
    public record GetUserByUsernameQuery : IRequest<UserDto>
    {
        public string Username { get; init; }
    }
}
