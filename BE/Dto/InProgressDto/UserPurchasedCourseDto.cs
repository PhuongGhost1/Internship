using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BE.Dto.CategoryCourse;
using BE.Dto.Certification;
using BE.Dto.Chapter;
using BE.Dto.ImageD;
using BE.Dto.User;
using BE.Dto.UserCertification;

namespace BE.Dto.InProgressDto
{
    public class UserPurchasedCourseDto
    {
        public string? CourseId { get; set; }
        public string? CourseName { get; set; }
        public List<ChaptersDto> Chapters { get; set; } = new List<ChaptersDto>();
        public List<UserProgressDto> UserProgress { get; set; } = new List<UserProgressDto>();
        public List<UserCertificationDto>? UserCertifications { get; set; }
        public List<ImageForAdminDto> Images { get; set; } = new List<ImageForAdminDto>();
        public List<CategoryCourseDto> CateCoruse = new List<CategoryCourseDto>();
        public UserInfoManageByAdminDto? User { get; set;}
    }
}