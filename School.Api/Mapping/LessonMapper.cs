using Microsoft.OpenApi.Extensions;
using School.Api.DTOs;
using School.Api.Entities;
using School.Api.Helpers;

namespace School.Api.Mapping
{
    public static class LessonMapper
    {
        public static Lesson ToLesson(this AddLessonDTO lessonDTO)
        {
            Lesson mappedLesson = new()
            {
                LessonName = lessonDTO.LessonName
            };

            return mappedLesson;

        }

        public static GetLessonDTO ToGetLessonDTO (this Lesson lesson)
        {
            GetLessonDTO mappedLesson = new()
            {
                LessonId = lesson.Id,
                LessonName = lesson.LessonName,
                rating = lesson.Rating,
                status = lesson.Status.MyGetDisplayName(),
                SubjectId = lesson.SubjectId
            };

            return mappedLesson;
        }
    }
}
