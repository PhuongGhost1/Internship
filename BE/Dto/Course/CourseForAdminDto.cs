using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BE.Dto.CategoryCourse;
using BE.Dto.ImageD;
using BE.Models;

namespace BE.Dto.Course
{
     public class CourseForAdminDto
     {
          public string? Id { get; set; }
          public string? Name { get; set; }
          public float? Rating { get; set; }
          public float? Price { get; set; }
          public List<ImageForAdminDto> Images { get; set; } = new List<ImageForAdminDto>();
          public List<CategoryCourseDto> CateCoruse = new List<CategoryCourseDto>();
     }
}