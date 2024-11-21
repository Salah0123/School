using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace School.Api.Entities
{
    // اولى تانية تالتة
    public class Grade : BaseEntity
    {
        [Required]
        public string GradeName { get; set; } = string.Empty;

        [ForeignKey("Level")]
        [Required]
        public string LevelId { get; set; }
        [JsonIgnore]
        public virtual Level Level { get; set; }

        [JsonIgnore]
        public virtual ICollection<Subject> Subjects { get; set; }
/*        public ICollection<Teacher> Teachers { get; set; }
*/    }
}
