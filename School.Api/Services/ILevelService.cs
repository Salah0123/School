using School.Api.DTOs;
using School.Api.Entities;

namespace School.Api.Services
{
    public interface ILevelService
    {
        Task<(ICollection<Level?>, string?)> GetAllAsync();
        Task<Level> GetByIdAsync(string id);
        Task<Level> CreateAsync(Level entity);
        Task<string?> DeleteAsync(string id);
        Task<(Level?,string?)> UpdateAsync(string id, AddLevelDTO entity);
    }
}
