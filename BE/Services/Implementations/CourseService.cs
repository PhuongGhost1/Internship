using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BE.Dto.Course;
using BE.Models;
using BE.Repository.Interface;
using BE.Services.Interfaces;
using Google.Cloud.Storage.V1;
using Google.Apis.Auth.OAuth2;
using Microsoft.AspNetCore.Mvc;
using BE.Mappers;
using BE.Helpers;
using BE.Dto.Course.Chapter;
using BE.Dto.Payment.CartCourse;
using BE.Dto.Message;

namespace BE.Services.Implementations
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepo;
        private readonly IImageRepository _imageRepo;
        private readonly IQuizRepository _quizRepo;
        private readonly ILectureRepository _lectureRepo;
        private readonly ICategoryRepository _cateRepo;
        private readonly IUserRepository _userRepo;
        private static readonly Random _random = new Random();
        public CourseService(ICourseRepository courseRepo, IImageRepository imageRepo, IQuizRepository quizRepo,
                            ILectureRepository lectureRepo, ICategoryRepository cateRepo, IUserRepository userRepo)
        {
            _courseRepo = courseRepo;
            _imageRepo = imageRepo;
            _quizRepo = quizRepo;
            _lectureRepo = lectureRepo;
            _cateRepo = cateRepo;
            _userRepo = userRepo;
        }

        public async Task<List<Course>> GetAllCourses(SearchQueryObject searchQueryObject)
        {
            var courses = await _courseRepo.GetAllCoursesByQueryName(searchQueryObject);
            return courses;
        }

        public async Task<List<Course>> FilterAllCourses(FilterQueryObject filterQueryObject)
        {
            var courses = await _courseRepo.FilterAllCoursesByObject(filterQueryObject);
            return courses;
        }

        public async Task<CourseDto> GetInformationOfCourse(string courseId)
        {
            var courseModel = await _courseRepo.RetriveCourseInformationById(courseId);

            if (courseModel == null) throw new Exception("Cannot find course!");

            var imageModel = await _imageRepo.GetImageByCourseId(courseId);

            if (imageModel == null) throw new Exception("Cannot find image!");

            var ratingAvg = await _courseRepo.RetriveRatingAverage(courseId);
            var ratingNum = await _courseRepo.RetriveRatingNumber(courseId);
            var NumberOfQuizInChapter = await _quizRepo.NumberOfQuizInChapterByCourseId(courseId);
            var totalVideoTimeMinutes = await _lectureRepo.CalculateTotalVideoTimeByCourseId(courseId);
            var courseDto = new CourseDto
            {
                Name = courseModel.Name,
                RatingAvg = ratingAvg,
                RatingNumber = ratingNum,
                EstimatedLearningTime = totalVideoTimeMinutes + NumberOfQuizInChapter * 30,
                ImageBackground = imageModel?.Url,
            };
            return courseDto;
        }

        public async Task<CourseDto?> GetLecturesAndQuizzesByCourseId(string courseId)
        {
            var course = await _courseRepo.RetriveCourseInformationById(courseId);

            if (course == null) throw new Exception("Cannot find course");

            var combinedList = await _courseRepo.GetLecturesAndQuizzesByCourseId(courseId);

            if (combinedList == null) throw new Exception("Not found lectures or quizzes!");

            return combinedList;
        }

        public async Task<string> UploadImgCourse(int courseId, IFormFile image)
        {
            if (image == null || image.Length == 0)
            {
                throw new ArgumentException("File is empty");
            }
            return "hi";
        }

        public async Task<string> CreateCourseData(CreateCoursData data)
        {
            return await _courseRepo.CreateCourseData(data);
        }

        public async Task<List<Course>> GetAllCoursesByCategoryName(string cateName)
        {
            var category = await _cateRepo.FindCategoryByName(cateName);

            if (category == null) throw new Exception("Not found category!");

            var courses = await _courseRepo.FindCourseByCategoryName(cateName);

            if (courses == null) throw new Exception("Not found course!");

            return courses;
        }

        public async Task<Course?> SearchCourseByUserId(string userId)
        {
            var user = await _userRepo.GetUserById(userId);

            if (user == null) throw new Exception("Unable to user!");

            var course = await _courseRepo.SearchCourseByUserId(userId);

            if (course == null) throw new Exception("Unable to search course!");

            return course;
        }

        public async Task<List<Course>> GetRecentRandomCourses(int numberOfCourses)
        {
            if (numberOfCourses < 0) throw new Exception("Cannot take under 0 course!");

            return await _courseRepo.GetRecentRandomCourses(6);
        }

        //---------------------CRUD--------------------------//

        public async Task<Course?> UpdateCourse(UpdateCourseDto updateCourseDto)
        {
            var course = await _courseRepo.RetriveCourseInformationById(updateCourseDto.CourseId);

            if (course == null) throw new Exception("Unable to find course!");

            var updateCourse = updateCourseDto.ToUpdateCourseDto();

            if (updateCourse == null) throw new Exception("Unable to update course!");

            return await _courseRepo.UpdateCourse(updateCourse);
        }

        public async Task<bool> DeleteCourse(string courseId)
        {
            var course = await _courseRepo.RetriveCourseInformationById(courseId);

            if (course == null) throw new Exception("Unable to find course!");

            return await _courseRepo.DeleteCourse(courseId);
        }

        public async Task<Course?> GetCourseByCourseName(string courseName)
        {
            if (courseName == null) throw new Exception("Unable to find chapter!");

            return await _courseRepo.FindCourseByCourseName(courseName);
        }

        public async Task<string> CreateChapter(CreateChapterData data)
        {
            return await _courseRepo.CreateChapter(data);
        }
        public async Task<string> CreateQuiz(CreateQuizData data)
        {
            return await _courseRepo.CreateQuiz(data);
        }

        public async Task<List<Course>> GetMostPurchasedCoursesAsync()
        {
            var courses = await _courseRepo.GetMostPurchasedCourses();

            if (courses == null || courses.Count == 0)
            {
                return new List<Course>();
            }

            return courses;
        }

        public async Task<List<MonthlyAnalyticsDto>> GetMonthlyExpenseAndRevenueAsync()
        {
            var chart = await _courseRepo.GetMonthlyExpenseAndRevenue();

            if (chart == null || chart.Count == 0)
            {
                return new List<MonthlyAnalyticsDto>();
            }

            return chart;
        }

        public async Task<List<CourseManagementForAdminDto>> GetCourseManagementByAdminAsync()
        {
            var courses = await _courseRepo.GetCourseManagementByAdmin();

            if (courses == null || courses.Count == 0) return new List<CourseManagementForAdminDto>();

            return courses;
        }

        public async Task<List<CourseManagementForAdminDto>> GetCourseManagementForWaitingByAdminAsync()
        {
            var courses = await _courseRepo.GetCourseManagementForWaitingByAdmin();

            if (courses == null || courses.Count == 0) return new List<CourseManagementForAdminDto>();

            return courses;
        }

        public async Task<bool> UpdateCourseByAdminAysnc(string courseId, int status)
        {
            var course = await _courseRepo.RetriveCourseInformationById(courseId);

            if (course == null) throw new Exception("Unable to find course!");

            return await _courseRepo.UpdateCourseByAdmin(courseId, status);
        }

        public async Task<List<CardCourseDto>> GetRandomCourse(int count)
        {
            var availableCourses = await _courseRepo.GetAllCourseAvailable();
            var randomCourses = availableCourses.OrderBy(x => _random.Next()).Take(count).ToList();
            var randomCoursesDto = new List<CardCourseDto>();

            foreach (var course in randomCourses)
            {
                var ratingCount = await _courseRepo.RetriveRatingNumber(course.Id);
                var timeLearning = await _courseRepo.TimeLearningCourse(course.Id);
                var imgUrl = await _courseRepo.GetImageCourse(course.Id, "Background");
                randomCoursesDto.Add(new CardCourseDto
                {
                    name = course.Name,
                    ratingAvg = course.Rating,
                    ratingCount = ratingCount,
                    timeLearning = timeLearning,
                    imgUrl = imgUrl
                });
            }

            return randomCoursesDto;
        }

        public async Task<List<CardCourseDto>> SearchCourse(string query, int page, int items)
        {
            var courses = await _courseRepo.SearchingCourse(query);
            var coursesPagination = courses.Skip((page - 1) * items).Take(items).ToList();
            var searchCourses = new List<CardCourseDto>();

            foreach (var course in coursesPagination)
            {
                var ratingCount = await _courseRepo.RetriveRatingNumber(course.Id);
                var timeLearning = await _courseRepo.TimeLearningCourse(course.Id);
                var imgUrl = await _courseRepo.GetImageCourse(course.Id, "Background");

                searchCourses.Add(new CardCourseDto
                {
                    name = course.Name,
                    ratingAvg = course.Rating,
                    ratingCount = ratingCount,
                    timeLearning = timeLearning,
                    imgUrl = imgUrl
                });
            }

            return searchCourses;
        }
        public async Task<bool> CreateCourse(CreateCourseDto course)
        {
            return await _courseRepo.CreateCourse(CourseMappers.ToCreateCourseDto(course));
        }
        public async Task<MessageDto> AddCourseToCart(CourseUserDto courseUser)
        {
            try
            {
                var cart = await _courseRepo.GetCart(courseUser.userId);
                if (cart == null)
                {
                    await _courseRepo.CreateCart(courseUser.userId);
                    cart = await _courseRepo.GetCart(courseUser.userId);
                }

                await _courseRepo.AddCourseToCart(cart, courseUser.courseId);

                return new MessageDto
                {
                    Message = "Add Course to cart Success",
                    Status = 1
                };
            }
            catch (Exception)
            {
                return new MessageDto
                {
                    Message = "Error add Course to cart",
                    Status = 0
                };
            }
        }
        public async Task<List<CartCourseCardDto>> GetListCartCourseByUser(string userId)
        {
            Cart? cart = await _courseRepo.GetCart(userId);
            if (cart != null)
            {
                List<CartCourse> cartCourses = await _courseRepo.GetListCartCourse(cart);
                foreach (CartCourse cartCourse in cartCourses)
                {

                }
                return null;
            }
            else
            {
                return null;
            }
        }
    }
}