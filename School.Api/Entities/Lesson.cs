using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School.Api.Entities
{
    public class Lesson : BaseEntity
    {
        [Required]
        public string LessonName { get; set; } = string.Empty;

        [ForeignKey("Subject")]
        [Required]
        public string SubjectId { get; set; }
        public virtual Subject Subject { get; set; }

        [ForeignKey("Grade")]
        [Required]
        public string GradeId { get; set; }
        public virtual Grade Grade { get; set; }

        public virtual ICollection<LessonResources> LessonResources { get; set; }
    }
}