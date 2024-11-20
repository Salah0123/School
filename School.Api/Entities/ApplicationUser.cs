using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace School.Api.Entities
{
    public class ApplicationUser :IdentityUser
    {
        [Required]
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Gender {  get; set; } = string.Empty;
    }
}