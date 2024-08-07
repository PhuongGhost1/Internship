using BE.Attributes;
using BE.Dto.Category;
using BE.Dto.Message;
using BE.Models;
using BE.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BE.Controllers
{
    [Route("api/v1/web/category")]
    [ApiController]
    public class CategoryWebController : ControllerBase
    {
        private readonly ICategoryService _cateService;
        public CategoryWebController(ICategoryService cateService)
        {
            _cateService = cateService;
        }

        [HttpGet]
        [Route("categories-list")]
        public async Task<List<Category>> GetAllCategories()
        {
            return await _cateService.GetAllCategories();
        }

        [HttpPut, Route("update-status-category")]
        public async Task<bool> UpdateStatusOfCategoryAsync([FromForm] string cateId)
        {
            return await _cateService.UpdateStatusOfCategoryAsync(cateId);
        }

        //---------------------CRUD--------------------------//
        //[CustomAuthorize("Admin")]
        [HttpPost]
        [Route("create-category")]
        public async Task<MessageDto?> CreateCategory([FromForm] CreateCategoryDto createCategoryDto){
            Console.WriteLine($"Create category: {createCategoryDto.Name}, {createCategoryDto.IsVisible}");
            return await _cateService.CreateCategory(createCategoryDto);
        }

        [CustomAuthorize("Admin")]
        [HttpPost]
        [Route("update-category")]
        public async Task<Category?> UpdateCategory([FromForm] UpdateCategoryDto updateCategoryDto){
            return await _cateService.UpdateCategory(updateCategoryDto);
        }

        [CustomAuthorize("Admin")]
        [HttpPost]
        [Route("delete-category")]
        public async Task<bool> DeleteCategory([FromForm] CategoryDto categoryDto){
            return await _cateService.DeleteCategory(categoryDto.cateId);
        }
    }
}