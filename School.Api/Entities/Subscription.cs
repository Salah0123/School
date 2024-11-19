using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School.Api.Entities
{
    public class Subscription
    {
        [Key]
        [Required]
        public string SubscriptionId { get; set; }

        [ForeignKey("Teacher")]
        [Required]
        public string Id { get; set; }
        public virtual Teacher Teacher { get; set; }

        [ForeignKey("SubscriptionTier")]
        [Required]
        public string SubscriptionTierId { get; set; }
        public virtual SubscriptionTier SubscriptionTier { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
