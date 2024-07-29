using BE.Dto.Course;
using BE.Helpers;
using BE.Dto.Course.Chapter;
using BE.Models;
using BE.Services.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using static BE.Utils.Utils;
using BE.Attributes;
using BE.Dto.Message;
using BE.Dto.User;
using BE.Dto.Course.FilterSearchCourse;
using Newtonsoft.Json;
using BE.Dto.Course.FilterSearchCourse.Item;

namespace BE.Controllers
{

    [Route("api/v1/web/course")]
    [ApiController]
    public class CourseWebController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CourseWebController(ICourseService courseService)
        {
            _courseService = courseService;
        }
        

        [HttpGet]
        [Route("all-courses")]
        public async Task<List<Course>> GetAllCourses([FromQuery] SearchQueryObject searchQueryObject)
        {
            return await _courseService.GetAllCourses(searchQueryObject);
        }

        [HttpGet]
        [Route("filter-all-courses")]
        public async Task<List<Course>> FilterAllCourses([FromQuery] FilterQueryObject filterQueryObject)
        {
            return await _courseService.FilterAllCourses(filterQueryObject);
        }

        [HttpPost]
        [Route("course-info")]
        public async Task<CourseDto> GetInformationOfCourse([FromForm] string courseId)
        {
            return await _courseService.GetInformationOfCourse(courseId);
        }

        // [CustomAuthorize("Student", "Instructor")]
        [HttpPost]
        [Route("content")]
        public async Task<CourseDto?> GetLecturesAndQuizzesByCourseId([FromForm] string courseId)
        {
            return await _courseService.GetLecturesAndQuizzesByCourseId(courseId);
        }

        //[CustomAuthorize("Instructor")]
        [HttpPost("upload-img")]
        public async Task<IActionResult> UploadImgCourse([FromForm] int courseId, [FromForm] IFormFile image)
        {
            var medialink = await _courseService.UploadImgCourse(courseId, image);
            return Ok(new { Medialink = medialink });
        }

        // [CustomAuthorize("Instructor")]
        // [HttpPost("create")]

        // public async Task<string> CreateCourse([FromForm] CreateCoursData data)
        // {
        //     return await _courseService.CreateCourse(data);
        // }


        [HttpPost]
        [Route("find-course-by-category")]
        public async Task<List<Course>> FindAllCoursesByCategoryName([FromForm] string cateName)
        {
            return await _courseService.GetAllCoursesByCategoryName(cateName);
        }

        [HttpPost]
        [Route("find-my-course-with-status")]

        public async Task<List<Course>> FindMyCoursesByStatus([FromForm] string userId, [FromForm] int status)
        {
            return await _courseService.GetCourseWithStatus(userId, status);
        }



        //---------------------CRUD--------------------------//

        //[CustomAuthorize("Instructor")]
        [HttpPost]
        [Route("update-course")]
        public async Task<Course?> UpdateCourse([FromForm] UpdateCourseDto updateCourseDto)
        {
            return await _courseService.UpdateCourse(updateCourseDto);
        }

        //[CustomAuthorize("Instructor")]
        [HttpPost]
        [Route("delete-course")]
        public async Task<bool> DeleteCourse([FromForm] string courseId)
        {
            return await _courseService.DeleteCourse(courseId);
        }

        [HttpPost, Route("find-course")]
        public async Task<CourseToCheckDto?> FindCourseByName([FromForm] string courseName, [FromForm] string? userId)
        {
            return await _courseService.GetCourseByCourseName(courseName, userId);
        }

        [HttpPost]
        [Route("search-course")]
        public async Task<Course?> SearchCourseByUserId([FromForm] string userId)
        {
            return await _courseService.SearchCourseByUserId(userId);
        }

        //[CustomAuthorize("Student", "Instructor")]
        [HttpPost]
        [Route("new-release-course")]
        public async Task<List<Course>> GetRecentRandomCourses([FromForm] int numberOfSize)
        {
            return await _courseService.GetRecentRandomCourses(numberOfSize);
        }

        // [CustomAuthorize("Instructor")]
        [HttpPost("createChapter")]
        public async Task<string> CreateChapter([FromForm] CreateChapterData data)
        {
            return await _courseService.CreateChapter(data);
        }

        [HttpPost("createQuiz")]
        public async Task<string> CreateQuiz([FromForm] CreateQuizData data)
        {
            return await _courseService.CreateQuiz(data);
        }

        [HttpPost("UploadVideo")]
        public async Task<MessageDto> UploadVideoLecture(
            [FromForm] string courseId,
            [FromForm] int chapterIndex,
            [FromForm] int lectureIndex,
            [FromForm] IFormFile video)
        {
            return await _courseService.AddVideoToCourse(courseId, chapterIndex, lectureIndex, video);
        }

        // [CustomAuthorize("Instructor")]
        [HttpGet("generate")]
        public async Task<string> GenerateId()
        {
            return GenerateIdModel("certification");
        }

        [CustomAuthorize("Instructor")]
        [HttpPost("test")]
        public async Task<string> HashTest([FromForm] string courseName)
        {
            return GenerateHashCode(courseName);
        }

        [HttpGet, Route("most-purchased-courses/{count:int}")]
        public async Task<List<NewReleaseCourseForHomepageDto>> GetMostPurchasedCourses(int count)
        {
            return await _courseService.GetMostPurchasedCoursesAsync(count);
        }

        [HttpGet, Route("monthly-expense-revenue")]
        public async Task<List<MonthlyAnalyticsDto>> GetMonthlyExpenseAndRevenue()
        {
            return await _courseService.GetMonthlyExpenseAndRevenueAsync();
        }

        [HttpGet, Route("manage-courses")]
        public async Task<List<CourseManagementForAdminDto>> TakeCourseManagementByAdmin()
        {
            return await _courseService.GetCourseManagementByAdminAsync();
        }

        [HttpGet, Route("manage-waiting-courses")]
        public async Task<List<CourseManagementForAdminDto>> TakeCourseManagementForWaitingByAdmin()
        {
            return await _courseService.GetCourseManagementForWaitingByAdminAsync();
        }

        [HttpPut, Route("update-course-management")]
        public async Task<bool> UpdateCourseByAdmin([FromForm] string courseId, [FromForm] int status)
        {
            return await _courseService.UpdateCourseByAdminAysnc(courseId, status);
        }

        [HttpGet, Route("random/{count:int}")]
        public async Task<List<CardCourseDto>> RandomCourse(int count)
        {
            return await _courseService.GetRandomCourse(count);
        }

        [HttpPost, Route("search")]
        public async Task<List<NewReleaseCourseForHomepageDto>> SearchCourse([FromForm] string? query, [FromQuery] int page, [FromQuery] int items)
        {
            return await _courseService.SearchCourse(query, page, items);
        }

        [HttpGet, Route("new-release-courses/{count:int}")]
        public async Task<List<NewReleaseCourseForHomepageDto>> GetNewReleaseCoursesAsync(int count)
        {
            return await _courseService.NewReleaseCoursesAsync(count);
        }

        [HttpGet, Route("top-rated-courses/{count:int}")]
        public async Task<List<NewReleaseCourseForHomepageDto>> GetTopRatedCoursesAsync(int count)
        {
            return await _courseService.GetTopRatedCoursesAsync(count);
        }

        [HttpPost, Route("create")]
        public async Task<bool> SearchCourse([FromForm] CreateCourseDto course)
        {
            return await _courseService.CreateCourse(course);
        }

        [HttpPost, Route("add-cart")]
        public async Task<MessageDto> AddCourseToCart([FromForm] CourseUserDto courseUser)
        {
            return await _courseService.AddCourseToCart(courseUser);
        }

        [HttpPost, Route("view-cart")]
        public async Task<UserCartDto> ViewCart([FromForm] string userId)
        {
            return await _courseService.GetListCartCourse(userId);
        }

        [HttpPost, Route("delete-item-cart")]
        public async Task<MessageDto> DeleteItemFromCart([FromForm] string cartCourseId)
        {
            return await _courseService.DeleteItemFromCart(cartCourseId);
        }
        [HttpPost, Route("pay-cart-course-items")]
        public async Task<MessageDto> PayCartCourses([FromBody] PayCartCourseDto data)
        {
            return await _courseService.PayCartCourses(data);
        }
        [HttpGet("is-course-in-cart")]
        public async Task<IActionResult> IsCourseInCart([FromQuery] string cartId, [FromQuery] string courseId)
        {
            bool result = await _courseService.IsCourseInCartAsync(cartId, courseId);
            return Ok(result);
        }

        [HttpPost, Route("search-filter")]
        public async Task<List<OutputFilterSearchDto>> SearchFilterCourses(
            [FromForm] InputString input,
            [FromQuery] int page,
            [FromQuery] int items)
        {
            var dto = new InputFilterSearchDto
            {
                Query = input.Query,
                Categories = string.IsNullOrEmpty(input.Categories) ? null : JsonConvert.DeserializeObject<List<string>>(input.Categories),
                PriceRange = string.IsNullOrEmpty(input.PriceRange) ? null : JsonConvert.DeserializeObject<List<int?>>(input.PriceRange),
                Ratings = string.IsNullOrEmpty(input.Ratings) ? null : JsonConvert.DeserializeObject<List<RatingObj>>(input.Ratings),
                Levels = string.IsNullOrEmpty(input.Levels) ? null : JsonConvert.DeserializeObject<List<LevelObj>>(input.Levels),
                UserId = input.UserId
            };
            return await _courseService.SearchFilterCourses(dto, page, items);
        }
        [HttpPost, Route("get-lecture")]
        public async Task<Lecture> GetLectureByHashCode([FromForm] string hashCode)
        {
            return await _courseService.GetLectureByHashCode(hashCode);
        }
        [HttpPost, Route("get-quiz")]
        public async Task<Quiz> GetQuizByHashCode([FromForm] string hashCode)
        {
            return await _courseService.GetQuizByHashCode(hashCode);
        }
        [HttpPost, Route("create-course-with-name")]
        public async Task<MessageDto> CreateCourseWithName([FromForm] string userId, [FromForm] string courseName, [FromForm] IFormFile image){
            return await _courseService.CreateCourseWithName(userId,courseName, image);
        }
    }
}