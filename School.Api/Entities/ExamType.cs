using System.ComponentModel.DataAnnotations;

namespace School.Api.Entities
{
    public class ExamType : BaseEntity
    {
        public string ExamTypeName { get; set; } = string.Empty;

        public virtual ICollection<Exam> Exams { get; set; }
    }
}
