using Microsoft.EntityFrameworkCore;
using School.Api.DTOs;
using School.Api.Entities;
using School.Api.Mapping;
using School.Api.Persistence;

namespace School.Api.Services
{
    public class LessonService : ILessonService
    {
        private readonly ApplicationDbContext _context;

        public LessonService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<(bool?, string?)> CreateAsync(string subjectId, Lesson entity)
        {
            var subject = await _context.Subjects.FindAsync(subjectId);
            if (subject == null) return (false, "Subject Not Found");

            var addedLesson = await _context.Lessons.AddAsync(entity);
            if (addedLesson == null) return (false, "Failed To add lesson");

            await _context.SaveChangesAsync();
            return (true, "Lesson added successfully");
        }

        public async Task<(bool?, string?)> DeleteAsync(string id)
        {
            var lesson = await _context.Lessons.FindAsync(id);
            if (lesson == null)
                return (false, "Lesson Not Found");

            _context.Lessons.Remove(lesson);

            await _context.SaveChangesAsync();

            return (true, "Lesson Deleted Successfully");
        }

        public Task<(ICollection<Lesson?>, string?)> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<(ICollection<GetLessonDTO>?, string?)> GetAllBySubjectAsync(string SubjectId)
        {
            var lessons = await _context.Lessons.Where(l => l.SubjectId == SubjectId).ToListAsync();

            if (lessons.Count == 0) return (null, "No Lessons Found");
            List<GetLessonDTO> lessonsDTO = [];
            foreach (var lesson in lessons)
            {
                lessonsDTO.Add(lesson.ToGetLessonDTO());
            }

            return (lessonsDTO, null);
        }

        public Task<(Lesson?, string?)> GetByIdAsync(string LessonId)
        {
            throw new NotImplementedException();
        }

        public async Task<(GetLessonDTO?, string?)> UpdateAsync(string id, UpdateLessonDTO entity)
        {
            var lesson = await _context.Lessons.FindAsync(id);
            if (lesson == null)
                return (null, "Lesson Not Found");

            lesson.LessonName = entity.LessonName;
            lesson.Status = entity.status;
            lesson.UpdatedOn = DateTime.Now;

            await _context.SaveChangesAsync();

            var updatedlessonDTO = lesson.ToGetLessonDTO();

            return (updatedlessonDTO, null);
        }
    }
}
