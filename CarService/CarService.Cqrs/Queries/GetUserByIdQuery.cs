using CarService.AppCore.Models;
using CarService.Domain.Models;
using MediatR;

namespace CarService.Cqrs.Queries
{
    public record GetUserByIdQuery: IRequest<CarOwner>
    {
        public GetUserByIdQuery(string userId) => UserId = userId;

        public string UserId { get; }
    }
}
