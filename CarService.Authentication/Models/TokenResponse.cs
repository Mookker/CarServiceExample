using System;

namespace CarService.Authentication.Models
{
    public class TokenResponse
    {
        public Guid UserId { get; set; }
        public string Token { get; set; }
        public DateTime ExpiresIn { get; set; }
    }
}
