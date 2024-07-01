using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BE.Models;
using BE.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace BE.Repository.Implementations
{
    public class ChapterRepository : IChapterRepository
    {
        private readonly CourseOnlContext _context;
        public ChapterRepository(CourseOnlContext context)
        {
            _context = context;
        }
        public async Task<int?> CountNumberChaptersByCourseId(string courseId)
        {
            var numberChapters = await
                                (from chap in _context.Chapters
                                join c in _context.Courses on chap.CourseId equals c.Id
                                where c.Id == courseId
                                select chap)
                                .CountAsync();

            return numberChapters;
        }


        //---------------------CRUD--------------------------//
        public async Task<Chapter?> FindChapterById(string chapId)
        {
            return await _context.Chapters.FirstOrDefaultAsync(chap => chap.Id == chapId);
        }

        public async Task<Chapter?> CreateChapter(Chapter chapter)
        {
            await _context.Chapters.AddAsync(chapter);
            await _context.SaveChangesAsync();
            return chapter;
        }

        public async Task<bool> DeleteChapter(string chapterId)
        {
            var chapter = await _context.Chapters.FindAsync(chapterId);

            if(chapter == null) return false;

            chapter.Status = 0;

            _context.Chapters.Update(chapter);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Chapter>> GetAllChapters()
        {
            return await _context.Chapters.ToListAsync();
        }

        public async Task<Chapter?> UpdateChapter(Chapter chapter)
        {
            _context.Chapters.Update(chapter);
            await _context.SaveChangesAsync();
            return chapter;
        }

        public async Task<Chapter?> FindChapterByName(string chapName)
        {
            if(chapName.Contains("-")){
                chapName = chapName.Replace("-", " ");
            }
            return await _context.Chapters.FirstOrDefaultAsync(chap => chap.Name.ToLower() == chapName.ToLower());
        }
    }
}