using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace School.Api.Entities
{
    public class Exam
    {
        [Key]
        [Required]
        public string ExamId { get; set; }
        [Required]
        public string ExamName { get; set; }

        [ForeignKey("Subject")]
        [Required]
        public string SubjectId { get; set; }
        public virtual Subject Subject { get; set; }

        [ForeignKey("Grade")]
        [Required]
        public string GradeId { get; set; }
        public virtual Grade Grade { get; set; }

        [ForeignKey("ExamType")]
        [Required]
        public string ExamTypeId { get; set; }
        public virtual ExamType ExamType { get; set; }

        public virtual ICollection<Question> ExamQuestions { get; set; }
        public virtual ICollection<ExamStudentScore> ExamStudentScores { get; set; }
    }
}
