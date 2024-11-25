using School.Api.Entities;
using System.ComponentModel.DataAnnotations;

namespace School.Api.DTOs
{
    public class UpdateLessonDTO
    {
        [Required]
        public string LessonName { get; set; }
        public LessonStatus status { get; set; }
    }
}
