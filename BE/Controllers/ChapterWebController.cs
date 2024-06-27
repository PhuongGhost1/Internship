using BE.Dto.Course.Chapter;
using BE.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BE.Controllers
{
    [Route("api/v1/web/chapter")]
    [ApiController]
    public class ChapterWebController : ControllerBase
    {
        private readonly IChapterService _chapterService;
        public ChapterWebController(IChapterService chapterService)
        {
            _chapterService = chapterService;
        }

        [HttpGet]
        [Route("chapters-in-course/{courseId}")]
        public async Task<ChapterDto> GetDataFromChapterInCourse([FromRoute] string courseId){
            return await _chapterService.GetDataFromChapterInCourse(courseId);
        }
    }
}