namespace School.Api.DTOs
{
    public class GetGradeDTO
    {
        public string Id { get; set; }
        public string GradeName { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int SubjectCount { get; set; }
        public string LevelId { get; set; }
        public string LevelName { get; set; }
    }
}
