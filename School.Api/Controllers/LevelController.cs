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
    public class LevelController : ControllerBase
    {
        private readonly ILevelService levelService;
        private readonly ApplicationDbContext _context;

        public LevelController(ILevelService levelService, ApplicationDbContext context)
        {
            this.levelService = levelService;
            _context = context;
        }


        [HttpGet("GetAllLevels")]
        public async Task<IActionResult> GetAllLevels()
        {
            var levels = await levelService.GetAllAsync();
            if(levels.Item1 == null)
                return NotFound();

            List<GetLevelDTO> levelsDto = [];

            foreach (var level in levels.Item1)
            {
                levelsDto.Add(level.ToGetLevelDto());
                levelsDto[^1].GradeCount = await _context.Grades.Where(g => g.LevelId == level.Id).CountAsync(); // Test This after adding grades to this level
            }

            if (levelsDto == null)
                return BadRequest();

            return Ok(levelsDto);
        }

        [HttpPost("AddLevel")]
        public async Task<IActionResult> AddLevelAsync(AddLevelDTO levelDTO)
        {
            if(!ModelState.IsValid) return BadRequest();

            var level = levelDTO.ToAddLevelDto();
            level.CreatedOn = DateTime.Now;

            var addedLevel = await levelService.CreateAsync(level);

            return Ok(addedLevel);

        }


        [HttpPatch("EditLevel/{id}")]
        public async Task<IActionResult> UpdateLevelAsync(string id, AddLevelDTO levelDTO)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = await levelService.UpdateAsync(id, levelDTO);

            if(result.Item1 == null)
                return BadRequest(levelDTO);

            return Ok(result.Item1);
        }

        [HttpDelete("DeleteRegion/{id}")]
        public async Task<IActionResult> DeleteLevelAsync(string id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await levelService.DeleteAsync(id);

            if (result == "Region Not Found")
                return NotFound(new { Message = result });

            return Ok(new { Message = result });
        }
    }
}
