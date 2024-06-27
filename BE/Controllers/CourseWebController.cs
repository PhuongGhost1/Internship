using BE.Dto.Course;
using BE.Models;
using BE.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BE.Controllers
{
    [Route("api/v1/web/course")]
    [ApiExplorerSettings(GroupName = "Web")]
    public class CourseWebController
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
    }
}