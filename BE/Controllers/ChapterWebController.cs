using BE.Dto.Course.Chapter;
using BE.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BE.Controllers
{
    [ApiController]
    [Route("api/v1/web/chapter")]
    public class ChapterWebController
    {
        private readonly IChapterService _chapterService;
        public ChapterWebController(IChapterService chapterService)
        {
            _chapterService = chapterService;
        }

        [HttpGet("chapters-in-course")]
        [Route("{courseId}")]
        public async Task<ChapterDto> GetDataFromChapterInCourse([FromRoute] string courseId){
            return await _chapterService.GetDataFromChapterInCourse(courseId);
        }
    }
}