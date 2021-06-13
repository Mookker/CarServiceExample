using System;

namespace CarService.AppCore.Models.Requests
{
    public record CreateCarOwnerRequest
    {
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public DateTime DoB { get; init; }
        public Guid CarId { get; init; }
    }
}
