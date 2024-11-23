using School.Api.DTOs;
using School.Api.Entities;

namespace School.Api.Services
{
    public interface IGradeService
    {
        Task<(ICollection<Grade?>, string?)> GetAllAsync();
        Task<ICollection<Grade>> GetGradesByLevelAsync(string LevelId);
        Task<Grade> GetByIdAsync(string id);
        Task<Grade> CreateAsync(string LevelId, Grade entity);
        Task<string?> DeleteAsync(string id);
        Task<(Grade?, string?)> UpdateAsync(string id, AddGradeDTO entity);
    }
}
