//using System.ComponentModel.DataAnnotations;
//using System.Text.Json.Serialization;

//namespace School.Api.Entities
//{
//    public class Subject
//    {
//        [Key]
//        [Required]
//        public string SubjectId { get; set; }
//        [Required]
//        public string SubjectName { get; set; } = string.Empty;

//        public DateTime CreatedOn { get; set; }

//        public virtual ICollection<Lesson> Lessons { get; set; }
//        public virtual ICollection<Grade> Grades { get; set; }
//*/    }
//}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
namespace School.Api.Entities
{
    public class Subject : BaseEntity
    {
        [Required]
        public string SubjectName { get; set; } = string.Empty;

        [ForeignKey("Grade")]
        public string GradeId { get; set; }
        [JsonIgnore]
        public virtual Grade Grade { get; set; }

        [JsonIgnore]
        public virtual ICollection<Lesson> Lessons { get; set; }

/*        public virtual ICollection<Teacher> Teachers { get; set; }
*/    }
}