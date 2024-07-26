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
using BE.Dto.ImageD;
using BE.Dto.Course.FilterSearchCourse;

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
        private readonly ICartRepository _cartRepo;
        private readonly IPaymentRepository _paymentRepo;
        private static readonly Random _random = new Random();
        public CourseService(ICourseRepository courseRepo, IImageRepository imageRepo, IQuizRepository quizRepo,
                            ILectureRepository lectureRepo, ICategoryRepository cateRepo, IUserRepository userRepo,
                            ICartRepository cartRepo, IPaymentRepository paymentRepo)
        {
            _courseRepo = courseRepo;
            _imageRepo = imageRepo;
            _quizRepo = quizRepo;
            _lectureRepo = lectureRepo;
            _cateRepo = cateRepo;
            _userRepo = userRepo;
            _cartRepo = cartRepo;
            _paymentRepo = paymentRepo;
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

        public async Task<List<Course>> GetCourseWithStatus(string userId, int status)
        {
            return await _courseRepo.GetCourseWithStatus(userId, status);
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
            var course = await _courseRepo.FindCourseByCourseName(courseName);
            Console.WriteLine(course);

            return course;
        }

        public async Task<string> CreateChapter(CreateChapterData data)
        {
            return await _courseRepo.CreateChapter(data);
        }
        public async Task<string> CreateQuiz(CreateQuizData data)
        {
            return await _courseRepo.CreateQuiz(data);
        }

        public async Task<List<NewReleaseCourseForHomepageDto>> GetMostPurchasedCoursesAsync(int count)
        {
            var courses = await _courseRepo.GetMostPurchasedCourses(count);

            if (courses == null || courses.Count == 0)
            {
                return new List<NewReleaseCourseForHomepageDto>();
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

        public async Task<List<NewReleaseCourseForHomepageDto>> SearchCourse(string query, int page, int items)
        {
            var courses = await _courseRepo.SearchingCourse(query);
            var coursesPagination = courses.Skip((page - 1) * items).Take(items).ToList();
            var searchCourses = new List<NewReleaseCourseForHomepageDto>();

            foreach (var course in coursesPagination)
            {
                var ratingCount = await _courseRepo.RetriveRatingNumber(course.Id);
                var totalVideoTime = await _courseRepo.CalculateTotalVideoTimeByCourseId(course.Id);
                var quizCount = await _courseRepo.NumberOfQuizInChapterByCourseId(course.Id);
                var image = new List<ImageForAdminDto> { await _courseRepo.GetImageForAdminDto(course.Id) };

                searchCourses.Add(new NewReleaseCourseForHomepageDto
                {
                    Id = course.Id,
                    Name = course.Name,
                    Price = course.Price,
                    RatingAvg = course.Rating,
                    RatingCount = ratingCount,
                    TimeLearning = totalVideoTime + quizCount * 30,
                    Level = course.Level,
                    Image = image
                });
            }

            return searchCourses;
        }

        public async Task<List<NewReleaseCourseForHomepageDto>> NewReleaseCoursesAsync(int count)
        {
            var newReleaseCourses = await _courseRepo.NewReleaseCourses(count);

            if (newReleaseCourses == null || newReleaseCourses.Count == 0) return new List<NewReleaseCourseForHomepageDto>();

            return newReleaseCourses;
        }


        public async Task<List<NewReleaseCourseForHomepageDto>> GetTopRatedCoursesAsync(int count)
        {
            var topRatedCourses = await _courseRepo.GetTopRatedCourses(count);

            if (topRatedCourses == null || topRatedCourses.Count == 0) return new List<NewReleaseCourseForHomepageDto>();

            return topRatedCourses;
        }
        public async Task<bool> CreateCourse(CreateCourseDto course)
        {
            return await _courseRepo.CreateCourse(CourseMappers.ToCreateCourseDto(course));
        }
        public async Task<MessageDto> AddCourseToCart(CourseUserDto courseUser)
        {
            try
            {
                Console.WriteLine("UserId: " + courseUser.UserId);
                var cart = await _courseRepo.GetCart(courseUser.UserId);
                if (cart == null)
                {
                    await _courseRepo.CreateCart(courseUser.UserId);
                    cart = await _courseRepo.GetCart(courseUser.UserId);
                }

                await _courseRepo.AddCourseToCart(cart, courseUser.CourseId);

                return new MessageDto
                {
                    Message = "Add Course to cart Success",
                    Status = 1
                };
            }
            catch (Exception e)
            {
                return new MessageDto
                {
                    Message = e.Message,
                    Status = 0
                };
            }
        }
        public async Task<List<CartCourseCardDto>> GetListCartCourseByUser(string userId)
        {
            var ListCartCourseReturn = new List<CartCourseCardDto>();
            Cart? cart = await _courseRepo.GetCart(userId);
            if (cart != null)
            {
                List<CartCourse> cartCourses = await _courseRepo.GetListCartCourse(cart);
                foreach (CartCourse cartCourse in cartCourses)
                {
                    string? imgUrl = await _courseRepo.GetImageCourse(cartCourse.Course.Id, "Background");
                    ListCartCourseReturn.Add(new CartCourseCardDto
                    {
                        cartCourse = cartCourse,
                        imgUrl = imgUrl
                    });
                }
            }
            return ListCartCourseReturn;
        }
        public async Task<MessageDto> DeleteItemFromCart(string cartCourseId)
        {
            try
            {
                CartCourse cartCourse = await _cartRepo.GetCartCourseById(cartCourseId);
                Cart cart = await _cartRepo.GetCartById(cartCourse.CartId);
                cart.Total -= cartCourse.Total;
                await _cartRepo.UpdateCart(cart);
                await _courseRepo.DeleteCartCoure(cartCourse);
                return new MessageDto
                {
                    Message = "Delete from cart success",
                    Status = 1
                };
            }
            catch (Exception e)
            {
                return new MessageDto
                {
                    Message = e.Message,
                    Status = 0
                };
            }
        }
        public async Task<MessageDto> PayCartCourses(PayCartCourseDto data)
        {
            try
            {
                float? totalMoney = 0;
                var cartCourses = await _courseRepo.GetListCartCourseByListId(data.CartCourseIds);
                //check wallet
                foreach (var cartCourse in cartCourses)
                {
                    totalMoney += cartCourse.Total;
                }
                var user = await _userRepo.GetUserById(data.UserId);
                if (user.Wallet < totalMoney)
                {
                    return new MessageDto
                    {
                        Message = "Insufficient balance",
                        Status = 2
                    };
                }
                user.Wallet -= totalMoney;
                await _userRepo.UpdateUserByObj(user);
                //Create Payment
                var payment = await _paymentRepo.CreatePaymentPayingCourse(data.UserId, totalMoney);
                foreach (var cartCourse in cartCourses)
                {
                    await _paymentRepo.CreatePaymentCourse(payment, cartCourse);
                    if (cartCourse.AffiliateId != null)
                    {
                        await _paymentRepo.CreatePaymentAffiliate(cartCourse, cartCourse.Affiliate);
                    }
                }

                return new MessageDto
                {
                    Message = "Pay course success",
                    Status = 1
                };
            }
            catch (Exception e)
            {
                return new MessageDto
                {
                    Message = e.Message,
                    Status = 0
                };
            }
        }
        public async Task<List<OutputFilterSearchDto>> SearchFilterCourses(InputFilterSearchDto dto, int page, int items)
        {
            var searchCourses = await _courseRepo.SearchingCourse(dto.Query);
            var filterCourses = await _courseRepo.FilterCourse(searchCourses, dto);
            var coursesPagination = filterCourses.Skip((page - 1) * items).Take(items).ToList();
            var searchFilterCourse = new List<OutputFilterSearchDto>();

            foreach (var course in coursesPagination)
            {
                var ratingCount = await _courseRepo.RetriveRatingNumber(course.Id);
                var timeLearning = await _courseRepo.TimeLearningCourse(course.Id);
                var imgUrl = await _courseRepo.GetImageCourse(course.Id, "Background");
                var lectureCount = await _courseRepo.CountLectureCourse(course.Id);
                var studentCount = await _courseRepo.CountEnrollCourse(course.Id);
                var isSaved = false;
                var instructorImg = await _userRepo.GetImageUser(course.UserId);
                var instructorName = (await _userRepo.GetUserById(course.UserId))?.Username;
                if (dto.UserId != null)
                {
                    isSaved = await _courseRepo.CheckSavedCourse(course.Id, dto.UserId);
                }
                searchFilterCourse.Add(new OutputFilterSearchDto
                {
                    CourseId = course.Id,
                    CourseImg = imgUrl,
                    CourseName = course.Name,
                    CourseLevel = course.Level,
                    LectureCount = lectureCount,
                    TimeTotal = timeLearning,
                    RatingAVG = course.Rating,
                    RatingCount = ratingCount,
                    StudentCount = studentCount,
                    Price = course.Price,
                    IsSaved = isSaved,
                    InstructorName = instructorName,
                    InstructorImg = instructorImg
                });
            }
            return searchFilterCourse;
        }
    }
}