using Microsoft.EntityFrameworkCore;
using School.Api.DTOs;
using School.Api.Entities;
using School.Api.Persistence;

namespace School.Api.Services
{
    public class SubjectService : ISubjectService
    {
        private readonly ApplicationDbContext _context;

        public SubjectService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Subject?> CreateAsync(string GradeId, Subject entity)
        {
            var GradeExist = await _context.Grades.FindAsync(GradeId);
            if (GradeExist == null) 
                throw new InvalidOperationException("Grade Not Found");

            var addedSubject = await _context.Subjects.AddAsync(entity);

            if (addedSubject == null || addedSubject.Entity == null) 
                throw new InvalidOperationException("there was a problem adding Subject");

            await _context.SaveChangesAsync();
            return addedSubject.Entity;


        }

        public async Task<string?> DeleteAsync(string id)
        {
            var subject = await _context.Subjects.FindAsync(id);
            if (subject == null)
                return "Subject Not Found";

            _context.Subjects.Remove(subject);

            await _context.SaveChangesAsync();

            return "Deleted Successfully";
        }

        public async Task<ICollection<Subject?>> GetAllAsync()
        {
            var subjects = await _context.Subjects.ToListAsync();
            if (subjects == null) throw new Exception("No Subjects Found");

            return subjects;
        }

        public Task<Subject?> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<Subject>> GetSubjectsByGradeAsync(string GradeId)
        {
            var grade = await _context.Grades.FindAsync(GradeId);
            if (grade == null) return null;
            var subjects = await _context.Subjects.Where(s => s.GradeId == GradeId).ToListAsync();
            if (subjects == null) throw new Exception("No Subjects Found For Specified Grade");

            return subjects;
        }

        public async Task<Subject?> UpdateAsync(string id, AddSubjectDTO entity)
        {
            var subject = await _context.Subjects.FindAsync(id);
            if (subject == null)
                throw new NullReferenceException("Subject Not Found");
            subject.SubjectName = entity.SubjectName;
            subject.UpdatedOn = DateTime.Now;
            await _context.SaveChangesAsync();

            return subject;
        }
    }
}
