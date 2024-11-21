using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School.Api.Entities
{
    public class Region : BaseEntity
    {
        [Required]
        public string RegionName { get; set; }

        [ForeignKey("SubscriptionTier")]

        public string? SubscriptionTierId { get; set; }
        public virtual SubscriptionTier SubscriptionTier { get; set; }
    }
}
