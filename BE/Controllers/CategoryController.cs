using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BE.Mappers;
using BE.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace BE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _cateRepo;
        public CategoryController(ICategoryRepository cateRepo)
        {
            _cateRepo = cateRepo;
        }

        [HttpGet("categories-list")]
        public async Task<IActionResult> GetAllCategories(){
            if(!ModelState.IsValid) return BadRequest(ModelState);

            var categories = await _cateRepo.GetCategories();

            if(categories == null) return BadRequest("No categories in stock!");

            return Ok(categories.ToCategoryList());
        }
    }
}