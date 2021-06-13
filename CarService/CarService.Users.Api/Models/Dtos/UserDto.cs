using System;
using CarService.Users.Api.Models.Domain;

namespace CarService.Users.Api.Models.Dtos
{
    public record UserDto
    {
        public UserDto(User user)
        {
            _ = user ?? throw new ArgumentNullException(nameof(user));
            Id = user.Id;
            FirstName = user.FirstName;
            LastName = user.LastName;
            DoB = user.DoB;
            CarId = user.CarId;
        }

        public Guid Id { get; init; }
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public DateTime DoB { get; init; }
        public Guid CarId { get; init; }
    }
}
