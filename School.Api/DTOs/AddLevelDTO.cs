using System.ComponentModel.DataAnnotations;

namespace School.Api.DTOs
{
    public class AddLevelDTO
    {
        [Required]
        public string LevelName { get; set; } = string.Empty;
    }
}
