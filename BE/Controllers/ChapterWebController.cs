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
        [Route("chapters-in-course")]
        public async Task<ChapterDto> GetDataFromChapterInCourse([FromBody] ChaptersDto chaptersDto){
            return await _chapterService.GetDataFromChapterInCourse(chaptersDto.CourseId);
        }



        //---------------------CRUD--------------------------//
        [HttpGet]
        [Route("view-all-chapter")]
        public async Task<List<Chapter>> GetDataFromChapterInCourse(){
            return await _chapterService.ViewAllChapters();
        }

        [HttpPost]
        [Route("create-chapter")]
        public async Task<Chapter?> CreateChapter([FromBody] CreateChapterDto createChapterDto){
            return await _chapterService.CreateChapter(createChapterDto);
        }

        [HttpPost]
        [Route("update-chapter")]
        public async Task<Chapter?> UpdateChapter([FromBody] UpdateChapterDto updateChapterDto){
            return await _chapterService.UpdateChapter(updateChapterDto);
        }

        [HttpPost]
        [Route("delete-chapter")]
        public async Task<bool> DeleteChapter([FromBody] ChaptersDto chaptersDto){
            return await _chapterService.DeleteChapter(chaptersDto.ChapId);
        }

        [HttpPost]
        [Route("find-chapter")]
        public async Task<Chapter?> FindChapterByName([FromBody] string chapName){
            return await _chapterService.GetChapterByName(chapName);
        }
    }
}