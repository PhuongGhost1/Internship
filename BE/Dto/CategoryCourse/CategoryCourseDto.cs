using BE.Dto.Category;
using BE.Dto.Course;

namespace BE.Dto.CategoryCourse
{
     public class CategoryCourseDto
     {
          public string Id { get; set; } = null!;
          public CategoryDto? Category { get; set; }
          public CourseManagementForAdminDto? Course { get; set; }
          public DateTime? CreatedAt { get; set; }
     }
}