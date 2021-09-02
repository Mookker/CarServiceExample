using System;

namespace CarService.Users.Api.Models.Domain
{
    public class User
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string[] Roles { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DoB { get; set; }
        public Guid CarId { get; set; }

        public override bool Equals(object obj)
        {
            return obj is User user &&
                   Id.Equals(user.Id) &&
                   Username == user.Username &&
                   Password == user.Password &&
                   FirstName == user.FirstName &&
                   LastName == user.LastName &&
                   DoB == user.DoB &&
                   CarId.Equals(user.CarId);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Username, Password, FirstName, LastName, DoB, CarId);
        }
    }
}
