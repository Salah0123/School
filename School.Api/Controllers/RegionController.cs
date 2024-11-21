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
    public class RegionController : ControllerBase
    {
        private readonly IRegionService regionService;

        public RegionController(IRegionService regionService)
        {
            this.regionService = regionService;
        }


        [HttpGet("GetAllRegions")]
        public async Task<IActionResult> GetAllRegions()
        {
            var regions = await regionService.GetAllAsync();
            if(regions == null)
                return NotFound();
            List<GetRegionDTO> regionsDto = [];
            foreach (var region in regions)
            {
               regionsDto.Add(region.ToGetRegionDto());
                regionsDto[^1].TeacherCount = 0; //Logic needs to be edited after adding teacher realtionship with region
            }
            if(regionsDto == null)
                return BadRequest();

            return Ok(regionsDto);
        }


        [HttpPost("AddRegion")]
        public async Task<IActionResult> AddRegionAsync(AddRegionDTO regionDTO)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var region = regionDTO.ToAddRegionDto();
            region.CreatedOn = DateTime.Now;

            var addedRegion = await regionService.CreateAsync(region);
            if (addedRegion == null)
                return BadRequest();

            return Ok(addedRegion);
        }

        [HttpPatch("EditRegion/{id}")]
        public async Task<IActionResult> UpdateRegionAsync(string id, AddRegionDTO regionDto)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var update = await regionService.UpdateAsync(id, regionDto);
            if (update.Item1 == null)
                return BadRequest(regionDto);

            return Ok(update.Item1);

        }

        [HttpDelete("DeleteRegion/{id}")]
        public async Task<IActionResult> DeleteRegionAsync(string id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await regionService.DeleteAsync(id);

            if (result == "Region Not Found")
                return NotFound(new { Message = result });

            return Ok(new { Message = result });
        }

    }
}
