using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BE.Dto.Course;
using BE.Dto.User;

namespace BE.Dto.SaveCourse
{
    public class SaveCourseDto
    {
        public string? Id { get; set; }
        public CourseInfoFollowingDto? Course { get; set; }
        public BasicInfoUser? User { get; set; }
        public bool StatusSaveCourse {get; set;}
    }
}