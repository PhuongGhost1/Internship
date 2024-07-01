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
        public async Task<Category?> CreateCategory([FromBody] CreateCategoryDto createCategoryDto){
            return await _cateService.CreateCategory(createCategoryDto);
        }

        [HttpPost]
        [Route("update-category/{cateId}")]
        public async Task<Category?> UpdateCategory([FromRoute] string cateId, [FromBody] UpdateCategoryDto updateCategoryDto){
            return await _cateService.UpdateCategory(cateId, updateCategoryDto);
        }

        [HttpPost]
        [Route("delete-category/{cateId}")]
        public async Task<bool> DeleteCategory([FromRoute] string cateId){
            return await _cateService.DeleteCategory(cateId);
        }
    }
}