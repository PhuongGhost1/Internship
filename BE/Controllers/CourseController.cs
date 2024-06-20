using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BE.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace BE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseController : ControllerBase
    {
        private readonly ICourseRepository _courseRepo;
        public CourseController(ICourseRepository courseRepo)
        {
            _courseRepo = courseRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCourses(){
            if(!ModelState.IsValid) return BadRequest(ModelState);

            var courses = await _courseRepo.GetAllCourses();
            
            if(courses == null) return BadRequest("Chua co course trong he thong!");

            return Ok(courses);
        }
    }
}