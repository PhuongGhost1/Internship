using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BE.Dto.CategoryCourse;
using BE.Dto.ImageD;
using BE.Dto.SaveCourse;
using BE.Dto.User;

namespace BE.Dto.Course
{
    public class CourseToCheckDto
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public float? Rating { get; set; }
        public float? Price { get; set; }
        public string? Description {get; set;}
        public List<ImageForAdminDto> Images { get; set; } = new List<ImageForAdminDto>();
        public List<CategoryCourseDto> CateCoruse = new List<CategoryCourseDto>();
        public List<SaveCourseDto> SaveCourses {get; set; } = new List<SaveCourseDto>();
        public UserInfoFollowingDto? User {get; set;}
    }
}