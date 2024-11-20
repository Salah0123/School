using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School.Api.Entities
{
    public class SubscriptionTier : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        [Column(TypeName = "decimal(5, 2)")]
        public decimal Discount { get; set; }

        public virtual ICollection<Subscription> Subscriptions { get; set; }
    }
}
