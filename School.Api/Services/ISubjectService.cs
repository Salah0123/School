using School.Api.DTOs;
using School.Api.Entities;

namespace School.Api.Services
{
    public interface ISubjectService
    {
        Task<ICollection<Subject?>> GetAllAsync();
        Task<ICollection<Subject>> GetSubjectsByGradeAsync(string GradeId);
        Task<Subject?> GetByIdAsync(string id);
        Task<Subject?> CreateAsync(string GradeId, Subject entity);
        Task<string?> DeleteAsync(string id);
        Task<Subject?> UpdateAsync(string id, AddSubjectDTO entity);
    }
}
