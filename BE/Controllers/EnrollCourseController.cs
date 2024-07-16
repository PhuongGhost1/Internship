using BE.Dto.EnrollCourse;
using BE.Models;
using BE.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using BE.Dto;
using BE.Dto.Course;

namespace BE.Controllers
{
    [ApiController]
    [Route("api/v1/web/enroll-course")]
    public class EnrollCourseWebController
    {
        private readonly IEnrollCourseService _enrollCourseService;
        public EnrollCourseWebController(IEnrollCourseService enrollCourseService)
        {
            _enrollCourseService = enrollCourseService;
        }

        [HttpPost]
        [Route("view-processing")]

        public async Task<List<CourseProcessingDto>> ViewCourseProcessing([FromForm] String userId)
        {
            return await _enrollCourseService.ViewCourseProcessing(userId);
        }


        //---------------------CRUD--------------------------//
        [HttpGet]
        [Route("view-all-enrollCourses")]
        public async Task<List<EnrollCourse>> ViewAllEnrollCourses()
        {
            return await _enrollCourseService.ViewAllEnrollCourses();
        }

        [HttpPost]
        [Route("create-enrollCourse")]
        public async Task<EnrollCourse?> CreateEnrollCourse([FromForm] CreateEnrollCourseDto createEnrollCourseDto)
        {
            return await _enrollCourseService.CreateEnrollCourse(createEnrollCourseDto);
        }

        [HttpPost]
        [Route("update-enrollCourse")]
        public async Task<EnrollCourse?> UpdateEnrollCourse([FromForm] string enrollCourseId, [FromForm] UpdateEnrollCourseDto updateEnrollCourseDto)
        {
            return await _enrollCourseService.UpdateEnrollCourse(enrollCourseId, updateEnrollCourseDto);
        }

        [HttpPost]
        [Route("delete-enrollCourse")]
        public async Task<bool> DeleteEnrollCourse([FromForm] string enrollCourseId)
        {
            return await _enrollCourseService.DeleteEnrollCourse(enrollCourseId);
        }
    }
}
