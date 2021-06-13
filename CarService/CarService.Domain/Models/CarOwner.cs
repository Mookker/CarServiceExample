using System;

namespace CarService.Domain.Models
{
    public record CarOwner
    {
        public Guid Id { get; init; }
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public DateTime DoB { get; init; }
        public Guid CarId { get; init; }
    }
}
