using CarService.Users.Api.Models.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarService.Users.Api.Cqrs.Commands
{
    public record UpdateUserCommand : IRequest<UserDto>
    {
        public Guid Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public DateTime DoB { get; }
        public Guid CarId { get; }

        public UpdateUserCommand(Guid id, string firstName, string lastName, DateTime doB, Guid carId)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            DoB = doB;
            CarId = carId;
        }
    }
}
