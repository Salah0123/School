using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School.Api.Entities
{
    public class LessonResources
    {
        [Key]
        [Required]
        public string ResourceId { get; set; }

        [ForeignKey("Lesson")]
        [Required]
        public string LessonId { get; set; }
        public virtual Lesson Lesson { get; set; }

        [Required]
        public string ResourceType { get; set; } = string.Empty;
        [Required]
        public string Resource { get; set; } = string.Empty;
    }
}
