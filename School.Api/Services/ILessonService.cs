using School.Api.DTOs;
using School.Api.Entities;

namespace School.Api.Services
{
    public interface ILessonService
    {
        Task<(ICollection<Lesson>?, string?)> GetAllAsync();
        Task<(ICollection<GetLessonDTO>?, string?)> GetAllBySubjectAsync(string SubjectId);
        Task<(Lesson?, string?)> GetByIdAsync(string LessonId);
        Task<(bool?, string?)> CreateAsync(string subjectId, Lesson entity);
        Task<(bool?, string?)> DeleteAsync(string id);
        Task<(GetLessonDTO?, string?)> UpdateAsync(string id, AddLessonDTO entity);
    }
}
