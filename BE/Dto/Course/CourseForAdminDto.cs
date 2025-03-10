using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BE.Dto.CategoryCourse;
using BE.Dto.Chapter;
using BE.Dto.Course.Chapter;
using BE.Dto.ImageD;
using BE.Dto.Payment.CartCourse;
using BE.Dto.User;
using BE.Models;

namespace BE.Dto.Course
{
     public class CourseForAdminDto
     {
          public string? Id { get; set; }
          public string? Name { get; set; }
          public float? Rating { get; set; }
          public float? Price { get; set; }
          public string? Description {get; set;}
          public int? Status {get; set;}
        public bool? IsVisible {get; set;}
        public int? Processings {get; set;}
        public int? EstimatedLearningTime {get; set;}
        public List<ImageForAdminDto> Images { get; set; } = new List<ImageForAdminDto>();
          public List<CategoryCourseDto> CateCoruse = new List<CategoryCourseDto>();
          public List<ChapterItemDto> Chapters = new List<ChapterItemDto>();
         public UserInfoManageByAdminDto? User {get; set;}
        public List<CartCourseDto> CartCourses {get; set;} = new List<CartCourseDto>();
        public DateTime? CreatedAt {get; set;}
        public DateTime? UpdatedAt {get; set;}
    }
}