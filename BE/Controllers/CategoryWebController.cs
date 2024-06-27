using BE.Models;
using BE.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BE.Controllers
{
    [Route("api/v1/web/category")]
    [ApiExplorerSettings(GroupName = "Web")]
    public class CategoryWebController
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
    }
}