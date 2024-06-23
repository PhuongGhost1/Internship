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
    public class ChapterController : ControllerBase
    {
        private readonly IQuizRepository _quizRepo;
        private readonly ILectureRepository _lectureRepo;
        public ChapterController(IQuizRepository quizRepo, ILectureRepository lectureRepo)
        {
            _quizRepo = quizRepo;
            _lectureRepo = lectureRepo;
        }

        [HttpGet("chapters-in-course/{courseId}")]
        public async Task<IActionResult> GetDataFromChapterInCourse([FromRoute] string courseId){
            if(!ModelState.IsValid) return BadRequest(ModelState);

            var NumberOfQuizInChapter = await _quizRepo.NumberOfQuizInChapterByCourseId(courseId);
            var totalVideoTimeMinutes = await _lectureRepo.CalculateTotalVideoTimeByCourseId(courseId);

            return Ok();
        }
    }
}