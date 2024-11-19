using System.ComponentModel.DataAnnotations;

namespace School.Api.Entities
{
    //ابتدائي اعدادي ثانوي
    public class Level 
    {
        [Key]
        [Required]
        public string LevelId { get; set; }
        [Required]
        public string LevelName { get; set; } = string.Empty;

        public virtual ICollection<Grade> Grades { get; set; }
        public virtual ICollection<Teacher> Teachers { get; set; }
    }
}
