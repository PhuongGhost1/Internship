using BE.Dto.CategoryCourse;
using BE.Models;
using BE.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BE.Controllers
{
    [ApiController]
    [Route("api/v1/web/role-user")]
    public class CategoryCourseWebController 
    {
        private readonly ICategoryCourseService _categoryCourseService;
        public CategoryCourseWebController(ICategoryCourseService categoryCourseService)
        {
            _categoryCourseService = categoryCourseService;
        }


        //---------------------CRUD--------------------------//
        [HttpGet]
        [Route("view-all-categoryCourses")]
        public async Task<List<CategoryCourse>> ViewAllCategoryCourses(){
            return await _categoryCourseService.ViewAllCategoryCourses();
        }

        [HttpPost]
        [Route("create-categoryCourse")]
        public async Task<CategoryCourse?> CreateCategoryCourse([FromForm] CreateCategoryCourseDto createCategoryCourseDto){
            return await _categoryCourseService.CreateCategoryCourse (createCategoryCourseDto);
        }

        [HttpPost]
        [Route("update-categoryCourse")]
        public async Task<CategoryCourse?> UpdateCategoryCourse([FromForm] string categoryCourseId, [FromForm] UpdateCategoryCourseDto updateCategoryCourseDto){
            return await _categoryCourseService.UpdateCategoryCourse(categoryCourseId, updateCategoryCourseDto);
        }

        [HttpPost]
        [Route("delete-categoryCourse")]
        public async Task<bool> DeleteCategoryCourse([FromForm] string categoryCourseId){
            return await _categoryCourseService.DeleteCategoryCourse(categoryCourseId);
        }
    }
}
