using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BE.Dto.Course;
using BE.Dto.Course.Chapter;
using BE.Models;

namespace BE.Services.Interfaces
{
    public interface ICourseService
    {
        Task<List<Course>> GetAllCourses();
        Task<CourseDto> GetInformationOfCourse(string courseId);
        Task<string> UploadImgCourse(int courseId, IFormFile image);
        Task<string> CreateCourse(CreateCoursData data);
        Task<string> CreateChapter(CreateChapterData data);
        Task<string> CreateQuiz(CreateQuizData data);
    }
}