using System.ComponentModel.DataAnnotations;

namespace School.Api.Contracts.Authentication
{
    public class LoginRequest
    {
        [MaxLength(100)]
        public string Phone { get; set; } = string.Empty;
        [MaxLength(100)]
        public string Password { get; set; } = string.Empty;
    }
}
