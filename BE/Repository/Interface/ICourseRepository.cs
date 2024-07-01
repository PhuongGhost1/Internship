using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BE.Dto.Course;
using BE.Helpers;
using BE.Models;

namespace BE.Repository.Interface
{
    public interface ICourseRepository
    {
        Task<List<Course>> GetAllCoursesByQueryName(SearchQueryObject searchQueryObject);
        Task<List<Course>> FilterAllCoursesByObject(FilterQueryObject filterQueryObject);
        Task<Course?> RetriveCourseInformationById(string courseId);
        Task<float?> RetriveRatingAverage(string courseId);
        Task<int?> RetriveRatingNumber(string courseId);
        Task<List<object>> GetLecturesAndQuizzesByCourseId(string courseId);
        Task<string> CreateCourse(CreateCoursData data);
        Task<List<Course>> FindCourseByCategoryName(string categoryName);

        //---------------------CRUD--------------------------//
        Task<Course?> CreateCourse(Course course);
        Task<Course?> UpdateCourse(Course course);
        Task<bool> DeleteCourse(string courseId);
        Task<Course?> FindCourseByCourseName(string courseName);
    }
}