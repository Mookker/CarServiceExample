using System.ComponentModel.DataAnnotations;

namespace CarService.Authentication.Models
{
    public record LoginUserRequest
    {
        [Required]
        public string Username { get; init; }

        [Required]
        public string Password { get; init; }
    }
}
