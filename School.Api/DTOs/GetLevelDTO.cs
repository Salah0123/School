using System.ComponentModel.DataAnnotations;

namespace School.Api.DTOs
{
    public class GetLevelDTO
    {
        [Required]
        public string Id { get; set; }
        public string LevelName { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int GradeCount { get; set; }
    }
}
