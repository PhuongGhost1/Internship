using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BE.Dto.Course;
using BE.Helpers;
using BE.Dto.Course.Chapter;
using BE.Models;
using Microsoft.AspNetCore.Mvc;
using BE.Dto.User;
using BE.Dto.ImageD;
using BE.Dto.Course.FilterSearchCourse;

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
                Task<string> CreateCourseData(CreateCoursData data);
                Task<List<Course>> FindCourseByCategoryName(string categoryName);
                Task<Course?> SearchCourseByUserId(string userId);
                Task<List<Course>> GetRecentRandomCourses(int numberOfCourses);
                Task<List<NewReleaseCourseForHomepageDto>> GetMostPurchasedCourses(int count);
                Task<List<MonthlyAnalyticsDto>> GetMonthlyExpenseAndRevenue();
                Task<List<CourseManagementForAdminDto>> GetCourseManagementByAdmin();
                Task<List<CourseManagementForAdminDto>> GetCourseManagementForWaitingByAdmin();
                Task<bool> UpdateCourseByAdmin(string courseId, int status);
                Task<List<Course>> GetCourseWithStatus(string userId, int status);
                Task<List<Course>> GetAllCourseAvailable();
                Task<List<NewReleaseCourseForHomepageDto>> NewReleaseCourses(int count);
                Task<List<NewReleaseCourseForHomepageDto>> GetTopRatedCourses(int count);

                //---------------------CRUD--------------------------//
                Task<Course?> UpdateCourse(Course course);
                Task<bool> DeleteCourse(string courseId);
                Task<CourseToCheckDto?> FindCourseByCourseName(string courseName, string? userId);
                Task<string> CreateChapter(CreateChapterData data);
                Task<string> CreateQuiz(CreateQuizData data);
                Task<TimeSpan?> TimeLearningCourse(string courseId);
                Task<string?> GetImageCourse(string courseId, string type);
                Task<List<Course>> SearchingCourse(string query);
                Task<int> CountLectureCourse(string courseId);
                Task<bool> CreateCourse(Course course);
                Task<Cart?> GetCart(string userId);
                Task CreateCart(string userId);
                Task AddCourseToCart(Cart? cart, string courseId);
                Task<UserCartDto> GetListCartCourse(string userId);
                Task DeleteCartCoure(CartCourse cartCourse);
                Task<List<CartCourse>> GetListCartCourseByListId(List<string> cartCourseIds);
                Task<bool> IsCourseInCartAsync(string cartId, string courseId);
                Task<int?> CalculateTotalVideoTimeByCourseId(string courseId);
                Task<int?> NumberOfQuizInChapterByCourseId(string courseId);
                Task<ImageForAdminDto> GetImageForAdminDto(string courseId);
                Task<List<Course>> FilterCourse(List<Course> courses, InputFilterSearchDto dto);
                Task<bool> CheckSavedCourse(string courseId, string userId);
                Task<int> CountEnrollCourse(string courseId);
                Task AddVideoToLecture(string courseId, int chapterIndex, int lectureIndex, IFormFile video);
                Task<Lecture> GetLectureByHashCode(string hashCode);
                Task<Quiz> GetQuizByHashCode(string hashCode);
        }
}