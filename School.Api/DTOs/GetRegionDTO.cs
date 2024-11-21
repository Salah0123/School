using System.ComponentModel.DataAnnotations;

namespace School.Api.DTOs
{
    public class GetRegionDTO
    {
        public string Id { get; set; }
        [Required]
        public string RegionName { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int TeacherCount { get; set; }
    }
}
