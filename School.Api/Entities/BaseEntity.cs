using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School.Api.Entities
{
    public class BaseEntity
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [ForeignKey("UserCreated")]
        public string? CreatedById { get; set; }
        public ApplicationUser UserCreated { get; set; }

        [ForeignKey("UserUpdated")]
        public string? UpdatedById { get; set; }
        public ApplicationUser UserUpdated { get; set; }

        [ForeignKey("UserDeleted")]
        public string? DeletedBtId { get; set; }
        public ApplicationUser UserDeleted { get; set; }

        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set;}
        public DateTime? DeletedOn { get; set; }
        public bool IsDeleted { get; set; }

    }
}
