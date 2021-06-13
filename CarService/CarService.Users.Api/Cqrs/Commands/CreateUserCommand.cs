using System;
using CarService.Users.Api.Models.Dtos;
using MediatR;

namespace CarService.Users.Api.Cqrs.Commands
{
    public class CreateUserCommand : IRequest<UserDto>
    {
        public string FirstName { get; }
        public string LastName { get; }
        public DateTime DoB { get; }
        public Guid CarId { get; }

        public CreateUserCommand(string firstName, string lastName, DateTime doB, Guid carId)
        {
            FirstName = firstName;
            LastName = lastName;
            DoB = doB;
            CarId = carId;
        }
    }
}
