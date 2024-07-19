using BE.Attributes;
using BE.Dto.Course;
using BE.Dto.SaveCourse;
using BE.Models;
using BE.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BE.Controllers
{
    [ApiController]
    [Route("api/v1/web/save-course")]
    public class SaveCourseWebController
    {
        private readonly ISaveCourseService _saveCourseService;
        public SaveCourseWebController(ISaveCourseService saveCourseService)
        {
            _saveCourseService = saveCourseService;
        }


        //---------------------CRUD--------------------------//
        [CustomAuthorize("Student", "Instructor")]
        [HttpGet]
        [Route("view-all-saveCourses")]
        public async Task<List<SaveCourse>> ViewAllSaveCourses()
        {
            return await _saveCourseService.ViewAllSaveCourses();
        }

        //[CustomAuthorize("Student", "Instructor")]
        [HttpPost]
        [Route("create-saveCourse")]
        public async Task<SaveCourse?> CreateSaveCourse([FromForm] CreateSaveCourseDto createSaveCourseDto)
        {
            return await _saveCourseService.CreateSaveCourse(createSaveCourseDto);
        }

        [CustomAuthorize("Student", "Instructor")]
        [HttpPost]
        [Route("update-saveCourse")]
        public async Task<SaveCourse?> UpdateSaveCourse([FromForm] string saveCourseId, [FromForm] UpdateSaveCourseDto updateSaveCourseDto)
        {
            return await _saveCourseService.UpdateSaveCourse(saveCourseId, updateSaveCourseDto);
        }

        //[CustomAuthorize("Student", "Instructor")]
        [HttpPost]
        [Route("delete-saveCourse")]
        public async Task<bool> DeleteSaveCourse([FromForm] string saveCourseId)
        {
            return await _saveCourseService.DeleteSaveCourse(saveCourseId);
        }

        [HttpPost, Route("get-save-course")]
        public async Task<List<SaveCourseCard>> GetListSaveCourseByUserId([FromForm] string userId)
        {
            return await _saveCourseService.GetListSaveCourse(userId);
        }
    }
}
