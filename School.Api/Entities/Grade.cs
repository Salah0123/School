using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace School.Api.Entities
{
    // اولى تانية تالتة
    public class Grade
    {
        [Key]
        [Required]
        public string GradeId { get; set; }
        [Required]
        public string GradeName { get; set; } = string.Empty;

        public DateTime CreatedOn { get; set; }

        [ForeignKey("Level")]
        [Required]
        public string LevelId { get; set; }
        public virtual Level Level { get; set; }

        public ICollection<Subject> Subjects { get; set; }
/*        public ICollection<Teacher> Teachers { get; set; }
*/    }
}
