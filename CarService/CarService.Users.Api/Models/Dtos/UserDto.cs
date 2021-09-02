using CarService.Users.Api.Models.Domain;
using System;

namespace CarService.Users.Api.Models.Dtos
{
    public record UserDto
    {
        public UserDto(User user)
        {
            _ = user ?? throw new ArgumentNullException(nameof(user));
            Id = user.Id;
            Username = user.Username;
            Password = user.Password;
            Roles = user.Roles;
            FirstName = user.FirstName;
            LastName = user.LastName;
            DoB = user.DoB;
            CarId = user.CarId;
        }

        public Guid Id { get; init; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string[] Roles { get; set; }
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public DateTime DoB { get; init; }
        public Guid CarId { get; init; }
    }
}
