using System.ComponentModel.DataAnnotations;

namespace School.Api.DTOs
{
    public class AddSubjectDTO
    {
        [Required]
        public string SubjectName { get; set; }
    }
}
