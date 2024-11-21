using School.Api.DTOs;
using School.Api.Entities;
using System.Runtime.CompilerServices;

namespace School.Api.Mapping
{
    public static class GradeMapper
    {
        public static Grade ToGrade(this AddGradeDTO gradeDTO)
        {
            Grade grade = new();
            grade.GradeName = gradeDTO.GradeName;

            return grade;
        }

        public static GetGradeDTO ToGetGradeDTO (this Grade grade)
        {
            GetGradeDTO gradeDTO = new();
            gradeDTO.Id = grade.Id;
            gradeDTO.GradeName = grade.GradeName;
            gradeDTO.CreatedOn = grade.CreatedOn;
            gradeDTO.LevelId = grade.LevelId;

            return gradeDTO;
        }
    }
}
