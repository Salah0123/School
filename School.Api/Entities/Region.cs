using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School.Api.Entities
{
    public class Region
    {
        [Key]
        [Required]
        public string RegionId { get; set; }
        [Required]
        public string RegionName { get; set; }
        public int Count { get; set; }

        [ForeignKey("SubscriptionTier")]
        [Required]
        public string SubscriptionTierId { get; set; }
        public SubscriptionTier SubscriptionTier { get; set; }
    }
}
