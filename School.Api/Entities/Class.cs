using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School.Api.Entities
{
    // هل الفصل مرتبط بمادة ؟
    public class Class : BaseEntity
    {
        [Required]
        public string ClassName { get; set; }

        [ForeignKey("Grade")]
        [Required]
        public string GradeId { get; set; }
        public virtual Grade Grade { get; set; }

       /* [ForeignKey("Teacher")]
        public string Id {  get; set; }
        public virtual Teacher Teacher { get; set; }*/

        public int StudentCount { get; set; }
        
/*        public virtual ICollection<Student> Students { get; set; }   
*/    }
}
