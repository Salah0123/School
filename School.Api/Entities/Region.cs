using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School.Api.Entities
{
    public class Region : BaseEntity
    {
        [Required]
        public string RegionName { get; set; }
        public int TeacherCount { get; set; } = 0;

        [ForeignKey("SubscriptionTier")]
        [Required]
        public string SubscriptionTierId { get; set; }
        public SubscriptionTier SubscriptionTier { get; set; }
    }
}
