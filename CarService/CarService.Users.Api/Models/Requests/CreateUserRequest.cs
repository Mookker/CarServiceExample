using System;
using System.ComponentModel.DataAnnotations;

namespace CarService.Users.Api.Models.Requests
{
    public record CreateUserRequest
    {
        [Required]
        public string FirstName { get; init; }
        [Required]
        public string LastName { get; init; }
        [Required]
        public DateTime DoB { get; init; }
        [Required]
        public Guid CarId { get; init; }
    }
}
