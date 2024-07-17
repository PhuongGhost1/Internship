using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BE.Dto.Course;
using BE.Dto.ImageD;
using BE.Dto.RoleUser;

namespace BE.Dto.User.Instructor
{
    public class InstructorProfileDto
    {
        public string? Id {get; set;}
        public string? Email { get; set; }
        public string? Name { get; set; }
        public bool? IsVisible { get; set; }
        public List<ImageForAdminDto> Images { get; set; } = new List<ImageForAdminDto>();
        public string? Phone { get; set; }
        public DateTime? CreateAt { get; set; }
        public string? Description { get; set; }
        public List<RoleUserDto> RoleUsers { get; set; } = new List<RoleUserDto>();
        public List<CourseForAdminDto> Courses { get; set; } = new List<CourseForAdminDto>();
    }
}