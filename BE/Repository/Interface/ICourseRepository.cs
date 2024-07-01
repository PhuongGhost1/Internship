using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BE.Dto.Course;
using BE.Dto.Course.Chapter;
using BE.Models;

namespace BE.Repository.Interface
{
    public interface ICourseRepository
    {
        Task<List<Course>> GetAllCourses();
        Task<Course?> RetriveCourseInformationById(string courseId);
        Task<float?> RetriveRatingAverage(string courseId);
        Task<int?> RetriveRatingNumber(string courseId);
        Task<string> CreateCourse(CreateCoursData data);
        Task<string> CreateChapter(CreateChapterData data);
        Task<string> CreateQuiz(CreateQuizData data);
    }
}