using BE.Dto.Category;
using BE.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BE.Controllers
{
    [ApiController]
    [Route("api/v1/web/category")]
    public class CategoryWebController
    {
        private readonly ICategoryService _cateService;
        public CategoryWebController(ICategoryService cateService)
        {
            _cateService = cateService;
        }

        [HttpGet("categories-list")]
        public async Task<CategoryDto> GetAllCategories(){
            return await _cateService.GetAllCategories();
        }
    }
}