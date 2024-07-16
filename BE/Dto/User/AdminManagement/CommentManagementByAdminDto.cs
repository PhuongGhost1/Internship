using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BE.Dto.Course;

namespace BE.Dto.User.AdminManagement
{
    public class CommentManagementByAdminDto
    {
        public string? Id { get; set; }
        public CourseForAdminDto? Courses { get; set; }
        public UserInfoManageByAdminDto? Users { get; set; }
        public int? Rating { get; set; }
        public string? Comment1 { get; set; }
        public DateTime? CreatedAt { get; set; }
        public bool? IsVisible { get; set; }
    }
}