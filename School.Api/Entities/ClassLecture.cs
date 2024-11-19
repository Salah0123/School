using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace School.Api.Entities
{
    public class ClassLecture
    {
        [Key]
        [Required]
        public string LectureId { get; set; }

        [Required]
        public string LectureTitle;

        [ForeignKey("Subject")]
        [Required]
        public string SubjectId { get; set; }
        public virtual Subject Subject { get; set; }

        [ForeignKey("Class")]
        [Required]
        public string ClassId { get; set; }
        public virtual Class Class { get; set; }

        [ForeignKey("Grade")]
        [Required]
        public string GradeId { get; set; }
        public virtual Grade Grade { get; set; }

        public DateTime Date { get; set; }
    }
}
