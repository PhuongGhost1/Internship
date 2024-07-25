using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BE.Dto.Category;
using BE.Dto.CategoryCourse;
using BE.Dto.ImageD;

namespace BE.Dto.User
{
    public class CourseForProfileSeenDto
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public int? Processings {get; set;}
        public int? EstimatedLearningTime {get; set;}
        public List<ImageForAdminDto> Images { get; set; } = new List<ImageForAdminDto>();
        public List<CategoryCourseDto> CateCoruse = new List<CategoryCourseDto>();
    }
}