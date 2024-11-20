using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School.Api.Entities
{
    public class StudentsAttendance : BaseEntity
    {
        /*[ForeignKey("Student")]
        [Required]
        public string Id{ get; set; }
        public virtual Student? Student { get; set; }*/

        [ForeignKey("Lecture")]
        [Required]
        public string LectureId { get; set; }
        public virtual ClassLecture? Lecture { get; set; }

        public string Status { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
    }
}
