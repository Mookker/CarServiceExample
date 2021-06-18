using CarService.Users.Api.Models.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarService.Users.Api.Cqrs.Commands
{
    public record DeleteUserCommand : IRequest<UserDto>
    {
        public Guid Id { get; }

        public DeleteUserCommand(Guid id)
        {
            Id = id;
        }
    }
}
