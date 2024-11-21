using Microsoft.EntityFrameworkCore;
using School.Api.DTOs;
using School.Api.Entities;
using School.Api.Persistence;

namespace School.Api.Services
{
    public class LevelService : ILevelService
    {
        private readonly ApplicationDbContext _context;

        public LevelService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Level> CreateAsync(Level entity)
        {
            var addedLevel = await _context.Levels.AddAsync(entity);

            if (addedLevel == null || addedLevel.Entity == null)
                throw new InvalidOperationException("Failed to add the Level to Database.");

            await _context.SaveChangesAsync();

            return addedLevel.Entity;
        }

        public async Task<string?> DeleteAsync(string id)
        {
            var level = await _context.Levels.FindAsync(id);
            if (level == null)
                return "Region Not Found";

            _context.Levels.Remove(level);

            await _context.SaveChangesAsync();

            return "Deleted Successfully";
        }

        public async Task<(ICollection<Level>, string?)> GetAllAsync()
        {
            var levels = await _context.Levels.ToListAsync(); 
            if(levels == null)
                return (null, "No Levels Found");

            return (levels, null);

        }

        public Task<Level> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<(Level?, string?)> UpdateAsync(string id, AddLevelDTO entity)
        {
            var level = await _context.Levels.FindAsync(id);
            if (level == null)
                return (null, "Region Not Found");
            level.LevelName = entity.LevelName;
            level.UpdatedOn = DateTime.Now;
            await _context.SaveChangesAsync();

            return (level, "Region Updated");
        }
    }
}
