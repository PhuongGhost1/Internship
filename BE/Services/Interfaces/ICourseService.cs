using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BE.Dto.Course;
using BE.Models;

namespace BE.Services.Interfaces
{
    public interface ICourseService
    {
        Task<List<Course>> GetAllCourses();
        Task<CourseDto> GetInformationOfCourse(string courseId);
        Task<string> UploadImgCourse(int courseId, IFormFile image);
        Task<string> CreateCourse(CreateCoursData data);
    }
}