using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BE.Dto.Course;
using BE.Helpers;
using BE.Dto.Course.Chapter;
using BE.Models;
using BE.Dto.Message;
using BE.Dto.User;
using BE.Dto.Course.FilterSearchCourse;
using Microsoft.AspNetCore.Mvc;

namespace BE.Services.Interfaces
{
        public interface ICourseService
        {
                Task<List<Course>> GetAllCourses(SearchQueryObject searchQueryObject);
                Task<List<Course>> FilterAllCourses(FilterQueryObject filterQueryObject);
                Task<CourseDto> GetInformationOfCourse(string courseId);
                Task<CourseDto?> GetLecturesAndQuizzesByCourseId(string courseId);
                Task<string> UploadImgCourse(int courseId, IFormFile image);
                Task<string> CreateCourseData(CreateCoursData data);
                Task<List<Course>> GetAllCoursesByCategoryName(string cateName);
                Task<Course?> SearchCourseByUserId(string userId);
                Task<List<Course>> GetRecentRandomCourses(int numberOfCourses);
                Task<List<NewReleaseCourseForHomepageDto>> GetMostPurchasedCoursesAsync(int count);
                Task<List<MonthlyAnalyticsDto>> GetMonthlyExpenseAndRevenueAsync();
                Task<List<CourseManagementForAdminDto>> GetCourseManagementByAdminAsync();
                Task<List<CourseManagementForAdminDto>> GetCourseManagementForWaitingByAdminAsync();
                Task<bool> UpdateCourseByAdminAysnc(string courseId, int status);
                Task<List<Course>> GetCourseWithStatus(string userId, int status);
                Task<List<CardCourseDto>> GetRandomCourse(int count);
                Task<List<NewReleaseCourseForHomepageDto>> NewReleaseCoursesAsync(int count);
                Task<List<NewReleaseCourseForHomepageDto>> GetTopRatedCoursesAsync(int count);

                //---------------------CRUD--------------------------//
                Task<Course?> UpdateCourse(UpdateCourseDto updateCourseDto);
                Task<bool> DeleteCourse(string courseId);
                Task<CourseToCheckDto?> GetCourseByCourseName(string courseName, string userId);
                Task<string> CreateChapter(CreateChapterData data);
                Task<string> CreateQuiz(CreateQuizData data);
                Task<List<NewReleaseCourseForHomepageDto>> SearchCourse(string query, int page, int items);
                Task<bool> CreateCourse(CreateCourseDto course);
                Task<MessageDto> AddCourseToCart(CourseUserDto courseUser);
                Task<UserCartDto> GetListCartCourse(string userId);
                Task<MessageDto> DeleteItemFromCart(string cartCourseId);
                Task<MessageDto> PayCartCourses(PayCartCourseDto data);
                Task<bool> IsCourseInCartAsync(string cartId, string courseId);
                Task<List<OutputFilterSearchDto>> SearchFilterCourses(InputFilterSearchDto dto, int page, int items);
                Task<MessageDto> AddVideoToCourse(string courseId, int chapterIndex, int lectureIndex, IFormFile video);
                Task<Lecture> GetLectureByHashCode(string hashCode);
                Task<Quiz> GetQuizByHashCode(string hashCode);
        }
}