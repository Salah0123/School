using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School.Api.Entities
{
    public enum LessonStatus
    {
        [Display(Name = "انتظار")]
        Pending = 0,   // Default
        [Display(Name = "مقبول")]
        Accepted = 1,
        [Display(Name = "مرفوض")]
        Rejected = 2
    }

    public class Lesson : BaseEntity
    {
        [Required]
        public string LessonName { get; set; } = string.Empty;

        [Column(TypeName = "decimal(3, 2)")]
        public decimal Rating { get; set; }

        [Required]
        public LessonStatus Status { get; set; } = LessonStatus.Pending; // Default to Pending

        [ForeignKey("Subject")]
        [Required]
        public string SubjectId { get; set; }
        public virtual Subject Subject { get; set; }

        public virtual ICollection<LessonResources> LessonResources { get; set; }
    }
}