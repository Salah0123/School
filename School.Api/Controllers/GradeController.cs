using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School.Api.DTOs;
using School.Api.Mapping;
using School.Api.Persistence;
using School.Api.Services;

namespace School.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradeController : ControllerBase
    {
        private readonly IGradeService gradeService;
        private readonly ApplicationDbContext _context;

        public GradeController(IGradeService gradeService, ApplicationDbContext context)
        {
            this.gradeService = gradeService;
            this._context = context;
        }


        [HttpGet("GetAllGrades")]
        public async Task<IActionResult> GetAllGradesAsync()
        {
            var grades = await gradeService.GetAllAsync();
            if(grades.Item1 == null)
                return NotFound();

            List<GetGradeDTO> gradesDTO = [];

            foreach(var grade in grades.Item1)
            {
                gradesDTO.Add(grade.ToGetGradeDTO());
                gradesDTO[^1].SubjectCount = await _context.Subjects.Where(s => s.GradeId == grade.Id).CountAsync();
            }
            if (gradesDTO == null)
                return Ok("No Grades Found");

            return Ok(gradesDTO);
        }


        [HttpPost("AddGrade")]
        public async Task<IActionResult> AddGradeAsync(string levelId, AddGradeDTO gradeDto)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);

            var grade = gradeDto.ToGrade();
            grade.LevelId = levelId;
            grade.CreatedOn = DateTime.Now;

            var addedGrade = await gradeService.CreateAsync(levelId, grade);

            return Ok(addedGrade);
        }


        [HttpPatch("EditGrade/{id}")]
        public async Task<IActionResult> UpdateGradeAsync(string id, AddGradeDTO gradeDTO)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = await gradeService.UpdateAsync(id, gradeDTO);

            if (result.Item1 == null)
                return BadRequest(gradeDTO);

            return Ok(result.Item1);
        }


        [HttpDelete("DeleteGrade/{id}")]
        public async Task<IActionResult> DeleteGradeAsync(string id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await gradeService.DeleteAsync(id);

            if (result == "Region Not Found")
                return NotFound(new { Message = result });

            return Ok(new { Message = result });
        }
    }
}
