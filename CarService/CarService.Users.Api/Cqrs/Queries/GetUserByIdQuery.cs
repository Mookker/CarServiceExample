using CarService.Users.Api.Models.Dtos;
using MediatR;

namespace CarService.Users.Api.Cqrs.Queries
{
    public record GetUserByIdQuery : IRequest<UserDto>
    {
        public string UserId { get; }

        public GetUserByIdQuery(string userId)
        {
            UserId = userId;
        }
    }
}
