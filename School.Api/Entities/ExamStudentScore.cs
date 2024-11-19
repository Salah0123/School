using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School.Api.Entities
{
    public class ExamStudentScore
    {
        [Key]
        public string ScoreID { get; set; }
        [ForeignKey("Student")]
        [Required]
        public string Id { get; set; }
        public virtual Student Student { get; set; }

        [ForeignKey("Exam")]
        [Required]
        public string ExamId { get; set; }
        public virtual Exam Exam { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public decimal Score { get; set; }
        public string Notes { get; set; } = string.Empty;
    }
}
