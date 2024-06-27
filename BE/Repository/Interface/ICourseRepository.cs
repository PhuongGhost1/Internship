using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BE.Models;

namespace BE.Repository.Interface
{
    public interface ICourseRepository
    {
        Task<List<Course>> GetAllCourses();
        Task<Course?> RetriveCourseInformationById(string courseId);
        Task<float?> RetriveRatingAverage(string courseId);
        Task<int?> RetriveRatingNumber(string courseId);
        Task<List<object>> GetLecturesAndQuizzesByCourseId(string courseId);
    }
}