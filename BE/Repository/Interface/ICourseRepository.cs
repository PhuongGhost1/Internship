using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BE.Dto.Course;
using BE.Helpers;
using BE.Dto.Course.Chapter;
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
                Task<CourseDto?> GetLecturesAndQuizzesByCourseId(string courseId);
                Task<string> CreateCourse(CreateCoursData data);
                Task<List<Course>> FindCourseByCategoryName(string categoryName);
                Task<Course?> SearchCourseByUserId(string userId);
                Task<List<Course>> GetRecentRandomCourses(int numberOfCourses);
                Task<List<Course>> GetMostPurchasedCourses();
                Task<List<MonthlyAnalyticsDto>> GetMonthlyExpenseAndRevenue();

                //---------------------CRUD--------------------------//
                Task<Course?> CreateCourse(Course course);
                Task<Course?> UpdateCourse(Course course);
                Task<bool> DeleteCourse(string courseId);
                Task<Course?> FindCourseByCourseName(string courseName);
                Task<string> CreateChapter(CreateChapterData data);
                Task<string> CreateQuiz(CreateQuizData data);
        }
}