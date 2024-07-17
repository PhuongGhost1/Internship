using BE.Dto.Course;
using BE.Models;
using static BE.Utils.Utils;

namespace BE.Mappers
{
    public static class CourseMappers
    {
        public static Course ToCreateCourseDto(this CreateCourseDto createCourseDto)
        {
            return new Course
            {
                Id = GenerateIdModel("course"),
                CreateAt = GetTimeNow(),
                UserId = createCourseDto.UserId,
                Name = createCourseDto.Name,
                Status = 0,
                IsVisible = true,
                Rating = 0,
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