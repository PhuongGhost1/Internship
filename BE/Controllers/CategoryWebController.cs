using BE.Attributes;
using BE.Dto.Category;
using BE.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BE.Controllers
{
    [ApiController]
    [Route("api/v1/web/category")]
    [ApiExplorerSettings(GroupName = "Category")]
    public class CategoryWebController : ControllerBase
    {
        private readonly ICategoryService _cateService;
        public CategoryWebController(ICategoryService cateService)
        {
            _cateService = cateService;
        }

        [HttpGet("categories-list")]
        public async Task<CategoryDto> GetAllCategories()
        {
            return await _cateService.GetAllCategories();
        }


        //---------------------CRUD--------------------------//
        [CustomAuthorize("Admin")]
        [HttpPost]
        [Route("create-category")]
        public async Task<Category?> CreateCategory([FromForm] CreateCategoryDto createCategoryDto){
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