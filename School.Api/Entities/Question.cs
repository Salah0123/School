using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School.Api.Entities
{
    public class Question : BaseEntity
    {
        [ForeignKey("Exam")]
        [Required]
        public string ExamId { get; set; }
        public virtual Exam Exam { get; set; }

        public string QuestionType { get; set; } = string.Empty;
        public string QuestionText { get; set; } = string.Empty;

        public virtual ICollection<Answer> Answers { get; set; }
    }
}
