using System.ComponentModel.DataAnnotations;

namespace School.Api.DTOs
{
    public class AddLessonDTO
    {
        [Required]
        public string LessonName { get; set; }
    }
}
