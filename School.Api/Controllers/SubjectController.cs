using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School.Api.DTOs;
using School.Api.Entities;
using School.Api.Mapping;
using School.Api.Persistence;
using School.Api.Services;

namespace School.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectService subjectService;
        private readonly ApplicationDbContext _context;

        public SubjectController(ISubjectService subjectService, ApplicationDbContext context)
        {
            this.subjectService = subjectService;
            _context = context;
        }


        [HttpGet("GetAllSubjects")]
        public async Task<IActionResult> GetAllAsync()
        {
            var subjects = await subjectService.GetAllAsync();
            if (subjects == null)
                return NotFound();

            List<GetSubjectDTO> subjectsDTO = [];

            foreach (var subject in subjects)
            {
                subjectsDTO.Add(subject.ToGetSubjectDTO());

                subjectsDTO[^1].GradeName = await _context.Grades
                    .Where(g => g.Id == subject.GradeId)
                    .Select(g => g.GradeName)
                    .SingleOrDefaultAsync();

                var grade = await _context.Grades.SingleOrDefaultAsync(g => g.Id == subject.GradeId);

                var LevelId = await _context.Levels.Where(l => l.Id == grade.LevelId).Select(l => l.Id).SingleOrDefaultAsync();
                subjectsDTO[^1].LevelId = LevelId;

                var LevelName = await _context.Levels.Where(l => l.Id == LevelId).Select(l => l.LevelName).SingleOrDefaultAsync();
                subjectsDTO[^1].LevelName = LevelName;
            }

            if (subjectsDTO == null)
                return Ok("No Subjects Found");

            return Ok(subjectsDTO);
        }


        [HttpGet("GetByGradeId/{gradeId}")]
        public async Task<IActionResult> GetByGradeIdAsync(string gradeId)
        {
            var subjects = await subjectService.GetSubjectsByGradeAsync(gradeId);
            if (subjects == null)
                return NotFound("Invalid Grade Id");

            List<GetSubjectDTO> subjectsDTO = [];

            foreach (var subject in subjects)
            {
                subjectsDTO.Add(subject.ToGetSubjectDTO());

                subjectsDTO[^1].GradeName = await _context.Grades
                    .Where(g => g.Id == subject.GradeId)
                    .Select(g => g.GradeName)
                    .SingleOrDefaultAsync();

                var grade = await _context.Grades.SingleOrDefaultAsync(g => g.Id == subject.GradeId);

                var LevelId = await _context.Levels.Where(l => l.Id == grade.LevelId).Select(l => l.Id).SingleOrDefaultAsync();
                subjectsDTO[^1].LevelId = LevelId;

                var LevelName = await _context.Levels.Where(l => l.Id == LevelId).Select(l => l.LevelName).SingleOrDefaultAsync();
                subjectsDTO[^1].LevelName = LevelName;
            }

            if (subjectsDTO == null)
                return Ok("No Subjects Found");

            return Ok(subjectsDTO);
        }


        [HttpPost("AddSubject/{gradeId}")]
        public async Task<IActionResult> CreateAsync(string gradeId, AddSubjectDTO subjectDTO)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);

            var subject = subjectDTO.ToSubject();
            subject.GradeId = gradeId;
            subject.CreatedOn = DateTime.Now;

            var addedSubject = await subjectService.CreateAsync(gradeId, subject);

            if (addedSubject == null) return BadRequest(addedSubject);

            return Ok(addedSubject);
        }


        [HttpPatch("EditSubject/{subjectId}")]
        public async Task<IActionResult> UpdateAsync(string subjectId, AddSubjectDTO subjectDTO)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = await subjectService.UpdateAsync(subjectId, subjectDTO);

            if (result == null)
                return BadRequest(subjectDTO);

            return Ok(result);
        }


        [HttpDelete("DeleteSubject/{subjectId}")]
        public async Task<IActionResult> DeleteAsync(string subjectId)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await subjectService.DeleteAsync(subjectId);

            if (result == "Subject Not Found")
                return NotFound(new { Message = result });

            return Ok(new { Message = result });
        }
    }
}
