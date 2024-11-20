using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace School.Api.Entities
{
    public class Subject : BaseEntity
    {
        [Required]
        public string SubjectName { get; set; } = string.Empty;

        public virtual ICollection<Lesson> Lessons { get; set; }
        public virtual ICollection<Grade> Grades { get; set; }
/*        public virtual ICollection<Teacher> Teachers { get; set; }
*/    }
}