using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BE.Dto.Course;

namespace BE.Dto.User.AdminManagement
{
    public class ReportManagementByAdminDto
    {
        public string? Id { get; set; }
        public CourseForAdminDto? Courses { get; set; }
        public CommentManagementByAdminDto? Comments { get; set; }
        public UserInfoManageByAdminDto? ReportedUser { get; set; }
        public UserInfoManageByAdminDto? Reporter { get; set; }
        public string? Title { get; set; }
        public string? Message { get; set; }
        public int? Status { get; set; }
    }
}