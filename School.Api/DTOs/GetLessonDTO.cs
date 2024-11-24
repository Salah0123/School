using School.Api.Entities;

namespace School.Api.DTOs
{
    public class GetLessonDTO
    {
        public string LessonId { get; set; }
        public string LessonName { get; set; }
        public decimal rating { get; set; }
        public string status { get; set; }
        public string SubjectId { get; set; }
    }
}
