using BE.Dto.SaveCourse;
using BE.Models;
using static BE.Utils.Utils;

namespace BE.Mappers
{
    public static class SaveCourseMappers
    {
        public static SaveCourse ToCreateSaveCourse(this CreateSaveCourseDto createSaveCourseDto)
        {
            return new SaveCourse
            {
                Id = GenerateIdModel("savecourse"),
                CourseId = createSaveCourseDto.CourseId,
                UserId = createSaveCourseDto.UserId,
                Time = GetTimeNow()
            };
        }

        public static SaveCourse ToUpdateSaveCourse(this UpdateSaveCourseDto updateSaveCourseDto)
        {
            return new SaveCourse
            {
                CourseId = updateSaveCourseDto.CourseId,
                UserId = updateSaveCourseDto.UserId,
                Time = GetTimeNow()
            };
        }
    }
}