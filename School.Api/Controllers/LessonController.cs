using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using School.Api.DTOs;
using School.Api.Entities;
using School.Api.Mapping;
using School.Api.Persistence;
using School.Api.Services;

namespace School.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonController : ControllerBase
    {
        private readonly ILessonService lessonService;
        private readonly ApplicationDbContext _context;

        public LessonController(ILessonService lessonService, ApplicationDbContext context)
        {
            this.lessonService = lessonService;
            _context = context;
        }


        [HttpGet("GetLessonsBySubjectId{subjectId}")]
        public async Task<IActionResult> GetAllBySubjectAsync(string subjectId)
        {
            if (subjectId == null) return BadRequest("Subject Id is required");

            var lessons = await lessonService.GetAllBySubjectAsync(subjectId);

            if(lessons.Item1 == null) return Ok(lessons.Item2);

            return Ok(lessons.Item1);

        }


        [HttpPost("CreateLesson/{subjectId}")]
        public async Task<IActionResult> CreateAsync(string subjectId, AddLessonDTO lessonDTO)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);

            var lesson = lessonDTO.ToLesson();
            lesson.SubjectId = subjectId;
            lesson.CreatedOn = DateTime.Now;

            var addedLesson = await lessonService.CreateAsync(subjectId, lesson);

            if (addedLesson.Item1 == false) return BadRequest(addedLesson.Item2);

            return Ok(addedLesson.Item2);
        }


        [HttpPatch("EditLesson/{lessonId}")]
        public async Task<IActionResult> UpdateAsync(string lessonId, AddLessonDTO lessonDTO)
        {
            if (!ModelState.IsValid) return BadRequest(lessonDTO);

            var result = await lessonService.UpdateAsync(lessonId, lessonDTO);
            if(result.Item1 == null) return BadRequest(result.Item2);

            return Ok(result.Item1);
        }

        [HttpDelete("DeleteLesson/{lessonId}")]
        public async Task<IActionResult> DeleteAsync(string lessonId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await lessonService.DeleteAsync(lessonId);

            if (result.Item1 == false)
                return BadRequest(result.Item2);

            return Ok(result.Item2);
        }
    }
}
