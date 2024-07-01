using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BE.Dto.Chapter;
using BE.Dto.Course.Chapter;
using BE.Models;

namespace BE.Services.Interfaces
{
    public interface IChapterService
    {
        Task<ChapterDto> GetDataFromChapterInCourse(string courseId);


        //---------------------CRUD--------------------------//
        Task<List<Chapter>> ViewAllChapters();
        Task<Chapter?> CreateChapter(string courseId, CreateChapterDto createChapterDto);
        Task<Chapter?> UpdateChapter(string chapId, UpdateChapterDto updateChapterDto);
        Task<bool> DeleteChapter(string chapId);
    }
}