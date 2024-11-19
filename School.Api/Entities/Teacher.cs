using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace School.Api.Entities
{
    public class Teacher : ApplicationUser
    {
        [ForeignKey("Region")]
        public string RegionId { get; set; }
        public virtual Region Region { get; set; }

        public virtual ICollection<Student> Students { get; set; }

        public virtual ICollection<Subscription> Subscriptions { get; set; }

        public virtual ICollection<Subject> Subjects { get; set; }
        public virtual ICollection<Level> Levels { get; set; }
        public virtual ICollection<Grade> Grades { get; set; }
        public virtual ICollection<Class> Classes { get; set; }

    }
}
