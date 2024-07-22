using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BE.Dto.Course;
using BE.Dto.ImageD;

namespace BE.Dto.User
{
    public class UserInfoFollowingDto
    {
        public string? Id { get; set; }
        public string? Email { get; set; }
        public string? Name { get; set; }
        public List<ImageForAdminDto> Images { get; set; } = new List<ImageForAdminDto>();
        public int? CoursesCount { get; set; }
        public int? FollowerCount {get; set;}
        public int? FollowedCount {get; set;}
        public List<CourseInfoFollowingDto> Courses { get; set; } = new List<CourseInfoFollowingDto>();
        public List<UserInfoFollowingDto> FollowFolloweds { get; set; } = new List<UserInfoFollowingDto>();
        public List<UserInfoFollowingDto> FollowFollowers { get; set; } = new List<UserInfoFollowingDto>();
        public bool? StatusFollowing {get; set;}
    }
}