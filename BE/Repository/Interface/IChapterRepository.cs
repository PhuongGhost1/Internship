using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BE.Models;

namespace BE.Repository.Interface
{
    public interface IChapterRepository
    {
        Task<int?> CountNumberChaptersByCourseId(string courseId);

        //---------------------CRUD--------------------------//
        Task<Chapter?> FindChapterById(string chapId);
        Task<List<Chapter>> GetAllChapters();
        Task<Chapter?> CreateChapter(Chapter chapter);
        Task<Chapter?> UpdateChapter(Chapter chapter);
        Task<bool> DeleteChapter(string chapterId);
    }
}