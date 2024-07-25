using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BE.Dto.Course;
using BE.Dto.ImageD;

namespace BE.Dto.User
{
    public class UserProfileBeSeenDto
    {
        public string? Id {get; set;}
        public string? Username { get; set; }
        public string? Description { get; set; }
        public string? Email { get; set; }
        public DateTime? Dob { get; set; }
        public string? Phone { get; set; }
        public int? TotalStudents {get; set;}
        public int? TotalCourses {get; set;}
        public float? AverageRatingForCourses {get; set;}
        public List<ImageForAdminDto> Images { get; set; } = new List<ImageForAdminDto>();
        public List<CourseForProfileSeenDto> Courses { get; set; } = new List<CourseForProfileSeenDto>();
        public List<UserProfileBeSeenDto> FollowFollowers { get; set; } = new List<UserProfileBeSeenDto>();
    }
}