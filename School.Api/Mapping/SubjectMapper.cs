using School.Api.DTOs;
using School.Api.Entities;

namespace School.Api.Mapping
{
    public static class SubjectMapper
    {
        public static Subject ToSubject(this AddSubjectDTO subjectDTO)
        {
            Subject mappedSubject = new()
            {
                SubjectName = subjectDTO.SubjectName
            };

            return mappedSubject;
        }

        public static GetSubjectDTO ToGetSubjectDTO(this Subject subject)
        {
            GetSubjectDTO mappedSubject = new()
            {
                SubjectId = subject.Id,
                SubjectName = subject.SubjectName,
                CreatedOn = subject.CreatedOn,
                GradeId = subject.GradeId

            };

            return mappedSubject;
        }
    }
}
