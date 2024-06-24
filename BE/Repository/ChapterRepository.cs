using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BE.Models;
using BE.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace BE.Repository
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
    }
}