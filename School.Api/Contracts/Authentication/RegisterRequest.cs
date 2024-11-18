using School.Api.Abstractions.Consts;
using System.ComponentModel.DataAnnotations;

namespace School.Api.Contracts.Authentication
{
    public class RegisterRequest
    {
        [MaxLength(100)]
        //[RegularExpression(RegexPatterns.Phone,ErrorMessage ="Phone should be starts with +9665 and length should be 13 char")]
        public string PhoneNumber { get; set; } = string.Empty;
        [MaxLength(100)]
        [RegularExpression(RegexPatterns.Password,ErrorMessage = "Password should be at least 8 digits and should contains Lowercase, NonAlphanumeric and Uppercase")]
        public string Password { get; set; } = string.Empty;
        [MaxLength(100)]
        public string FirstName { get; set; } = string.Empty;
        [MaxLength(100)]
        public string LastName { get; set; } = string.Empty;
    }
}