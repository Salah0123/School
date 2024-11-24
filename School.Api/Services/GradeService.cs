using Microsoft.EntityFrameworkCore;
using School.Api.DTOs;
using School.Api.Entities;
using School.Api.Persistence;

namespace School.Api.Services
{
    public class GradeService : IGradeService
    {
        private readonly ApplicationDbContext _context;

        public GradeService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Grade> CreateAsync(string LevelId, Grade entity)
        {
            var level = await _context.Levels.FindAsync(LevelId);
            if(level == null)
                throw new InvalidOperationException("Level Not Found");

            var addedGrade = await _context.Grades.AddAsync(entity);

            if(addedGrade == null || addedGrade.Entity == null)
                throw new InvalidOperationException("Failed To Add Grade");

            await _context.SaveChangesAsync();

            return addedGrade.Entity;

        }

        public async Task<string?> DeleteAsync(string id)
        {
            var grade = await _context.Grades.FindAsync(id);
            if (grade == null)
                return "Subject Not Found";

            _context.Grades.Remove(grade);

            await _context.SaveChangesAsync();

            return "Deleted Successfully";
        }

        public async Task<(ICollection<Grade?>, string?)> GetAllAsync()
        {
            var grades = await _context.Grades.ToListAsync();
            if (grades == null)
                return (null, "No Grades Found");

            return (grades, null);
        }

        public Task<Grade> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        
        public async Task<(Grade?, string?)> UpdateAsync(string id, AddGradeDTO entity)
        {
            var grade = await _context.Grades.FindAsync(id);
            if (grade == null)
                return (null, "Grade Not Found");
            grade.GradeName = entity.GradeName;
            grade.UpdatedOn = DateTime.Now;
            await _context.SaveChangesAsync();

            return (grade, "Grade Updated");
        }

        public async Task<ICollection<Grade>> GetGradesByLevelAsync(string LevelId)
        {
            var level = await _context.Levels.FindAsync(LevelId);
            if (level == null) return null;
            var grades = await _context.Grades.Where(g => g.LevelId == LevelId).ToListAsync();
            if (grades == null)
                throw new Exception("No Grades found for specified Level");

            return grades;
        }
    }
}
