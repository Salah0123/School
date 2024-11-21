using School.Api.DTOs;
using School.Api.Entities;

namespace School.Api.Services
{
    public interface IRegionService
    {
        Task<ICollection<Region>> GetAllAsync();
        Task<(Region?, string?)> GetByIdAsync(string id);
        Task<Region> CreateAsync(Region entity);
        Task<string?> DeleteAsync(string id);
        Task<(Region?, string?)> UpdateAsync(string id, AddRegionDTO entity);

    }
}
