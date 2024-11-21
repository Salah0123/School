using School.Api.DTOs;
using School.Api.Entities;

namespace School.Api.Mapping
{
    public static class RegionMapper
    {
        
        public static Region ToAddRegionDto(this AddRegionDTO regionDTO)
        {
            var mappedRegion = new Region();
            mappedRegion.RegionName = regionDTO.RegionName;
            return mappedRegion;
        }
        public static GetRegionDTO ToGetRegionDto (this Region region)
        {
            var mappedRegion = new GetRegionDTO();
            mappedRegion.RegionName = region.RegionName;
            mappedRegion.CreatedOn = region.CreatedOn;
            mappedRegion.Id = region.Id;

            return mappedRegion;
        }
    }
}
