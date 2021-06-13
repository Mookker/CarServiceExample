using System;

namespace CarService.Users.Api.Models.Responses
{
    public record UserResponse
    {
        public string Id { get; init; }
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public DateTime DoB { get; init; }
        public string CarId { get; init; }
    }
}
