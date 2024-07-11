using BE.Dto.EnrollCourse;
using BE.Models;
using static BE.Utils.Utils;

namespace BE.Mappers
{
    public static class EnrollCourseMappers
    {
        public static EnrollCourse ToCreateEnrollCourse(this CreateEnrollCourseDto createEnrollCourseDto){
            return new EnrollCourse{
                Id = GenerateIdModel("enrollcourse"),
                CourseId = createEnrollCourseDto.CourseId,
                UserId = createEnrollCourseDto.UserId,
                Date = GetTimeNow()
            };
        }

        public static EnrollCourse ToUpdateEnrollCourse(this UpdateEnrollCourseDto updateEnrollCourseDto){
            return new EnrollCourse{
                CourseId = updateEnrollCourseDto.CourseId,
                UserId = updateEnrollCourseDto.UserId,
                Date = GetTimeNow()
            };
        }
    }
}