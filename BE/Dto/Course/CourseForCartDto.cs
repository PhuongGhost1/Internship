using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BE.Dto.ImageD;
using BE.Dto.User;

namespace BE.Dto.Course
{
    public class CourseForCartDto
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public float? Rating { get; set; }
        public float? Price { get; set; }
        public string? Description {get; set;}
        public string? imgUrl { get; set; }
        public UserInfoFollowingDto? User {get; set;}
    }
}