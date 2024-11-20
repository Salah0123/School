using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace School.Api.Entities
{
    /*public class Student : ApplicationUser
    {
        public string Status { get; set; } = string.Empty;
        public int Points { get; set; }

        [ForeignKey("Grade")]
        [Required]
        public string GradeId { get; set; }
        public virtual Grade? Grade { get; set; }

*//*        public virtual ICollection<Teacher>? Teachers { get; set; }
*//*        public virtual ICollection<Class>? Classes { get; set; }
        public virtual ICollection<StudentsAttendance>? StudentAttendances { get; set; }
    }*/
}
