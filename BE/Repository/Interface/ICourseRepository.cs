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
                Task<List<NewReleaseCourseForHomepageDto>> GetMostPurchasedCourses();
                Task<List<MonthlyAnalyticsDto>> GetMonthlyExpenseAndRevenue();
                Task<List<CourseManagementForAdminDto>> GetCourseManagementByAdmin();
                Task<List<CourseManagementForAdminDto>> GetCourseManagementForWaitingByAdmin();
                Task<bool> UpdateCourseByAdmin(string courseId, int status);
                Task<List<Course>> GetCourseWithStatus(string userId, int status);
                Task<List<Course>> GetAllCourseAvailable();
                Task<List<NewReleaseCourseForHomepageDto>> NewReleaseCourses();
                Task<List<NewReleaseCourseForHomepageDto>> NewReleaseCoursesByNam(int size);

                //---------------------CRUD--------------------------//
                Task<Course?> CreateCourse(Course course);
                Task<Course?> UpdateCourse(Course course);
                Task<bool> DeleteCourse(string courseId);
                Task<Course?> FindCourseByCourseName(string courseName);
                Task<string> CreateChapter(CreateChapterData data);
                Task<string> CreateQuiz(CreateQuizData data);
                Task<TimeSpan?> TimeLearningCourse(string courseId);
                Task<string?> GetImageCourse(string courseId, string type);
                Task<List<Course>> SearchingCourse(string query);
                Task<int> CountLectureCourse(string courseId);
        }
}