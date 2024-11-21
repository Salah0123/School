using System.ComponentModel.DataAnnotations;

namespace School.Api.DTOs
{
    public class AddGradeDTO
    {
        [Required]
        public string GradeName { get; set; } = string.Empty;

    }
}
