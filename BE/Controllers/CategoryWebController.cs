using BE.Dto.Category;
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
        public async Task<List<Category>> GetAllCategories(){
            return await _cateService.GetAllCategories();
        }


        //---------------------CRUD--------------------------//
        [HttpPost]
        [Route("create-category")]
        public async Task<Category?> CreateCategory([FromForm] CreateCategoryDto createCategoryDto){
            return await _cateService.CreateCategory(createCategoryDto);
        }

        [HttpPost]
        [Route("update-category")]
        public async Task<Category?> UpdateCategory([FromForm] UpdateCategoryDto updateCategoryDto){
            return await _cateService.UpdateCategory(updateCategoryDto);
        }

        [HttpPost]
        [Route("delete-category")]
        public async Task<bool> DeleteCategory([FromForm] CategoryDto categoryDto){
            return await _cateService.DeleteCategory(categoryDto.cateId);
        }
    }
}