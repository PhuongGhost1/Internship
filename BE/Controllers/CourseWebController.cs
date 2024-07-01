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
        [Route("course-info")]
        public async Task<CourseDto> GetInformationOfCourse([FromForm] string courseId){
            return await _courseService.GetInformationOfCourse(courseId);
        }

        [HttpGet]
        [Route("content")]
        public async Task<List<object>> GetLecturesAndQuizzesByCourseId([FromForm] string courseId)
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
        public async Task<List<Course>> FindAllCoursesByCategoryName([FromForm] string cateName){
            return await _courseService.GetAllCoursesByCategoryName(cateName);
        }


        //---------------------CRUD--------------------------//
        [HttpPost]
        [Route("create-course")]
        public async Task<Course?> CreateCourse([FromForm] CreateCourseDto createCourseDto){
            return await _courseService.CreateCourse(createCourseDto);
        }

        [HttpPost]
        [Route("update-course")]
        public async Task<Course?> UpdateCourse([FromForm] UpdateCourseDto updateCourseDto){
            return await _courseService.UpdateCourse(updateCourseDto);
        }

        [HttpPost]
        [Route("delete-course")]
        public async Task<bool> DeleteCourse([FromForm] string courseId){
            return await _courseService.DeleteCourse(courseId);
        }

        [HttpPost]
        [Route("find-course")]
        public async Task<Course?> FindCourseByName([FromForm] string courseName){
            return await _courseService.GetCourseByCourseName(courseName);
        }
    }
}