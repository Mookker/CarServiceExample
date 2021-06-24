using CarService.Users.Api.Models.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarService.Users.Api.Cqrs.Queries
{
    public record GetAllUsersQuery : IRequest<IEnumerable<UserDto>>
    {

    }
}
