using BE.Dto.Course;
using BE.Models;
using BE.Services.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using static BE.Utils.Utils;

namespace BE.Controllers
{
    [ApiController]
    [Route("api/v1/web/course")]
    [ApiExplorerSettings(GroupName = "Course")]
    public class CourseWebController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CourseWebController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
        [Route("all-courses")]
        public async Task<List<Course>> GetAllCourses(){
            return await _courseService.GetAllCourses();
        }

        [HttpGet]
        [Route("course-info/{courseId}")]
        public async Task<CourseDto> GetInformationOfCourse([FromRoute] string courseId){
            return await _courseService.GetInformationOfCourse(courseId);
        }

        [HttpGet]
        [Route("content/{courseId}")]
        public async Task<List<object>> GetLecturesAndQuizzesByCourseId([FromRoute] string courseId)
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

        
        [HttpGet]
        [Route("find-course-by-category/{cateName}")]
        public async Task<List<Course>> FindAllCoursesByCategoryName([FromRoute] string cateName){
            return await _courseService.GetAllCoursesByCategoryName(cateName);
        }
    }
}