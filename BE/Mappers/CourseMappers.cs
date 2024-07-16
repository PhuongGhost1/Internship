using BE.Dto.Course;
using BE.Models;
using static BE.Utils.Utils;

namespace BE.Mappers
{
    public static class CourseMappers
    {
        public static Course ToCreateCourseDto(this CreateCourseDto createCourseDto, string userId)
        {
            return new Course
            {
                Id = GenerateIdModel("course"),
                CreateAt = GetTimeNow(),
                UserId = userId,
                Name = createCourseDto.Name,
                Description = createCourseDto.Description,
                Price = createCourseDto.Price,
                WhatLearn = createCourseDto.WhatLearn
            };
        }

        public static Course ToUpdateCourseDto(this UpdateCourseDto updateCourseDto)
        {
            return new Course
            {
                UpdateAt = GetTimeNow(),
                Name = updateCourseDto.Name,
                Description = updateCourseDto.Description,
                Price = updateCourseDto.Price,
                WhatLearn = updateCourseDto.WhatLearn
            };
        }
    }
}