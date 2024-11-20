using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School.Api.Entities
{
    public class Answer : BaseEntity
    {
        [ForeignKey("Question")]
        [Required]
        public string QuestionId { get; set; }
        public virtual Question Question { get; set; }
        [Required]
        public string AnswerText { get; set; } = string.Empty;
        [Required]
        public bool IsCorrect { get; set; }
    }
}
