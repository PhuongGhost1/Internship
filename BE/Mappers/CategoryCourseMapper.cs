using BE.Dto.CategoryCourse;
using BE.Models;
using static BE.Utils.Utils;

namespace BE.Mappers
{
    public static class CategoryCourseMappers
    {
        public static CategoryCourse ToCreateCategoryCourse(this CreateCategoryCourseDto createCategoryCourseDto){
            return new CategoryCourse{
                Id = GenerateIdModel("categorycourse"),
                CourseId = createCategoryCourseDto.CourseId,
                CategoryId = createCategoryCourseDto.CategoryId,
                CreatedAt = GetTimeNow()
            };
        }

        public static CategoryCourse ToUpdateCategoryCourse(this UpdateCategoryCourseDto updateCategoryCourseDto){
            return new CategoryCourse{
                CourseId = updateCategoryCourseDto.CourseId,
                CategoryId = updateCategoryCourseDto.CategoryId,
                CreatedAt = GetTimeNow()
            };
        }
    }
}