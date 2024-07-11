using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BE.Dto.Course;

namespace BE.Dto.Notification
{
    public class NotificationDto
    {
        public string? Description { get; set; }
        public DateTime? DateUp { get; set; }
        public string? Type { get; set; }
        public CourseForAdminDto? Course { get; set; }
    }
}