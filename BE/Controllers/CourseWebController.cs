using BE.Dto.Course;
using BE.Helpers;
using BE.Dto.Course.Chapter;
using BE.Models;
using BE.Services.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using static BE.Utils.Utils;

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

        [HttpGet]
        [Route("course-info")]
        public async Task<CourseDto> GetInformationOfCourse([FromBody] string courseId)
        {
            return await _courseService.GetInformationOfCourse(courseId);
        }

        [HttpGet]
        [Route("content")]
        public async Task<List<object>> GetLecturesAndQuizzesByCourseId([FromBody] string courseId)
        {
            return await _courseService.GetLecturesAndQuizzesByCourseId(courseId);
        }

        [HttpPost("upload-img")]

        public async Task<IActionResult> UploadImgCourse([FromForm] int courseId, [FromForm] IFormFile image)
        {
            var medialink = await _courseService.UploadImgCourse(courseId, image);
            return Ok(new { Medialink = medialink });
        }

        [HttpPost("create")]

        public async Task<string> CreateCourse([FromForm] CreateCoursData data)
        {
            return await _courseService.CreateCourse(data);
        }


        [HttpPost]
        [Route("find-course-by-category")]
        public async Task<List<Course>> FindAllCoursesByCategoryName([FromForm] string cateName)
        {
            return await _courseService.GetAllCoursesByCategoryName(cateName);
        }


        //---------------------CRUD--------------------------//
        [HttpPost]
        [Route("create-course")]
        public async Task<Course?> CreateCourse([FromBody] CreateCourseDto createCourseDto)
        {
            return await _courseService.CreateCourse(createCourseDto);
        }

        [HttpPost]
        [Route("update-course")]
        public async Task<Course?> UpdateCourse([FromBody] UpdateCourseDto updateCourseDto)
        {
            return await _courseService.UpdateCourse(updateCourseDto);
        }

        [HttpPost]
        [Route("delete-course")]
        public async Task<bool> DeleteCourse([FromBody] string courseId)
        {
            return await _courseService.DeleteCourse(courseId);
        }

        [HttpPost]
        [Route("find-course")]
        public async Task<Course?> FindCourseByName([FromForm] string courseName)
        {
            return await _courseService.GetCourseByCourseName(courseName);
        }

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

        public async Task<string> UploadVideoLecture([FromForm] IFormFile video)
        {
            return await UploadVideoToFirebase(video, "Python", 1, 1);
        }
        [HttpGet("generate")]
        public async Task<string> GenerateId()
        {
            return GenerateIdModel("category");
        }
        [HttpPost("test")]
        public async Task<string> HashTest([FromForm] string courseName)
        {
            return GenerateHashCode(courseName);
        }
    }
}