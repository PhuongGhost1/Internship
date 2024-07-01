using BE.Dto.Course;
using BE.Helpers;
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
        public async Task<List<Course>> GetAllCourses([FromQuery] SearchQueryObject searchQueryObject){
            return await _courseService.GetAllCourses(searchQueryObject);
        }

        [HttpGet]
        [Route("filter-all-courses")]
        public async Task<List<Course>> FilterAllCourses([FromQuery] FilterQueryObject filterQueryObject){
            return await _courseService.FilterAllCourses(filterQueryObject);
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


        //---------------------CRUD--------------------------//
        [HttpPost]
        [Route("create-course/{userId}")]
        public async Task<Course?> CreateCourse([FromRoute] string userId, [FromBody] CreateCourseDto createCourseDto){
            return await _courseService.CreateCourse(userId, createCourseDto);
        }

        [HttpPost]
        [Route("update-course/{courseId}")]
        public async Task<Course?> UpdateCourse(UpdateCourseDto updateCourseDto, string courseId){
            return await _courseService.UpdateCourse(updateCourseDto, courseId);
        }

        [HttpPost]
        [Route("delete-course/{courseId}")]
        public async Task<bool> DeleteCourse([FromRoute] string courseId){
            return await _courseService.DeleteCourse(courseId);
        }
    }
}