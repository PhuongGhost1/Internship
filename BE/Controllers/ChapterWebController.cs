using BE.Attributes;
using BE.Dto.Chapter;
using BE.Dto.Course.Chapter;
using BE.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BE.Controllers
{
    [ApiController]
    [Route("api/v1/web/chapter")]
    [ApiExplorerSettings(GroupName = "Chapter")]
    public class ChapterWebController : ControllerBase
    {
        private readonly IChapterService _chapterService;
        public ChapterWebController(IChapterService chapterService)
        {
            _chapterService = chapterService;
        }

        [CustomAuthorize("Student", "Instructor")]
        [HttpGet]
        [Route("chapters-in-course")]
        public async Task<ChapterDto> GetDataFromChapterInCourse([FromForm] ChaptersDto chaptersDto){
            return await _chapterService.GetDataFromChapterInCourse(chaptersDto.CourseId);
        }



        //---------------------CRUD--------------------------//
        [CustomAuthorize("Student", "Instructor")]
        [HttpGet]
        [Route("view-all-chapter")]
        public async Task<List<Chapter>> GetDataFromChapterInCourse(){
            return await _chapterService.ViewAllChapters();
        }

        [CustomAuthorize("Instructor")]
        [HttpPost]
        [Route("create-chapter")]
        public async Task<Chapter?> CreateChapter([FromForm] CreateChapterDto createChapterDto){
            return await _chapterService.CreateChapter(createChapterDto);
        }

        [CustomAuthorize("Instructor")]
        [HttpPost]
        [Route("update-chapter")]
        public async Task<Chapter?> UpdateChapter([FromForm] UpdateChapterDto updateChapterDto){
            return await _chapterService.UpdateChapter(updateChapterDto);
        }

        [CustomAuthorize("Instructor")]
        [HttpPost]
        [Route("delete-chapter")]
        public async Task<bool> DeleteChapter([FromForm] ChaptersDto chaptersDto){
            return await _chapterService.DeleteChapter(chaptersDto.ChapId);
        }
    }
}