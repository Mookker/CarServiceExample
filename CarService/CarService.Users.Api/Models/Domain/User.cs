using System;

namespace CarService.Users.Api.Models.Domain
{
    public class User
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DoB { get; set; }
        public Guid CarId { get; set; }
    }
}
