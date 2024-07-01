using BE.Dto.Chapter;
using BE.Dto.Course.Chapter;
using BE.Models;
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



        //---------------------CRUD--------------------------//
        [HttpGet]
        [Route("view-all-chapter")]
        public async Task<List<Chapter>> GetDataFromChapterInCourse(){
            return await _chapterService.ViewAllChapters();
        }

        [HttpPost]
        [Route("create-chapter/{courseId}")]
        public async Task<Chapter?> CreateChapter([FromRoute] string courseId, [FromBody] CreateChapterDto createChapterDto){
            return await _chapterService.CreateChapter(courseId, createChapterDto);
        }

        [HttpPost]
        [Route("update-chapter/{chapId}")]
        public async Task<Chapter?> UpdateChapter([FromRoute] string chapId, [FromBody] UpdateChapterDto updateChapterDto){
            return await _chapterService.UpdateChapter(chapId, updateChapterDto);
        }

        [HttpPost]
        [Route("delete-chapter/{chapId}")]
        public async Task<bool> DeleteChapter([FromRoute] string chapId){
            return await _chapterService.DeleteChapter(chapId);
        }
    }
}