using CarService.Users.Api.Models.Domain;
using CarService.Users.Api.Models.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarService.Users.Api.Cqrs.Queries
{
    public record GetUserByCarIdQuery : IRequest<UserDto>
    {
        public Guid CarId { get; }

        public GetUserByCarIdQuery(Guid carId)
        {
            CarId = carId;
        }
    }
}
