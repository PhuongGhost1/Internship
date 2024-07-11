using BE.Attributes;
using BE.Dto.EnrollCourse;
using BE.Models;
using BE.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BE.Controllers
{
    [ApiController]
    [Route("api/v1/web/role-user")]
    public class EnrollCourseWebController 
    {
        private readonly IEnrollCourseService _enrollCourseService;
        public EnrollCourseWebController(IEnrollCourseService enrollCourseService)
        {
            _enrollCourseService = enrollCourseService;
        }


        //---------------------CRUD--------------------------//
        [CustomAuthorize("Student", "Instructor")]
        [HttpGet]
        [Route("view-all-enrollCourses")]
        public async Task<List<EnrollCourse>> ViewAllEnrollCourses(){
            return await _enrollCourseService.ViewAllEnrollCourses();
        }

        [CustomAuthorize("Student", "Instructor")]
        [HttpPost]
        [Route("create-enrollCourse")]
        public async Task<EnrollCourse?> CreateEnrollCourse([FromForm] CreateEnrollCourseDto createEnrollCourseDto){
            return await _enrollCourseService.CreateEnrollCourse (createEnrollCourseDto);
        }

        [CustomAuthorize("Student", "Instructor")]
        [HttpPost]
        [Route("update-enrollCourse")]
        public async Task<EnrollCourse?> UpdateEnrollCourse([FromForm] string enrollCourseId, [FromForm] UpdateEnrollCourseDto updateEnrollCourseDto){
            return await _enrollCourseService.UpdateEnrollCourse(enrollCourseId, updateEnrollCourseDto);
        }

        [CustomAuthorize("Student", "Instructor")]
        [HttpPost]
        [Route("delete-enrollCourse")]
        public async Task<bool> DeleteEnrollCourse([FromForm] string enrollCourseId){
            return await _enrollCourseService.DeleteEnrollCourse(enrollCourseId);
        }
    }
}
