using Microsoft.AspNetCore.Identity;

namespace School.Api.Entities
{
    public class ApplicationRole : IdentityRole
    {
        public bool IsDefault { get; set; }
        public bool IsDeleted { get; set; }
    }
}
