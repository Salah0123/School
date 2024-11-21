using School.Api.DTOs;
using School.Api.Entities;

namespace School.Api.Mapping
{
    public static class LevelMapper
    {
        public static GetLevelDTO ToGetLevelDto(this Level level)
        {
            var mappedLevel = new GetLevelDTO();
            mappedLevel.LevelName = level.LevelName;
            mappedLevel.Id = level.Id;
            mappedLevel.CreatedOn = level.CreatedOn;

            return mappedLevel;
        }

        public static Level ToAddLevelDto (this AddLevelDTO levelDTO)
        {
            var mappedLevel = new Level();
            mappedLevel.LevelName = levelDTO.LevelName;

            return mappedLevel;
        }
    }
}
