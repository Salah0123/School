namespace School.Api.DTOs
{
    public class GetSubjectDTO
    {
        public string SubjectId { get; set; }
        public string SubjectName { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string GradeId { get; set; }
        public string GradeName { get; set; }
        public string LevelId { get; set; }
        public string LevelName { get; set; }
    }
}
