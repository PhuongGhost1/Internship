using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BE.Models;
using BE.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace BE.Repository
{
    public class QuizRepository : IQuizRepository
    {
        private readonly CourseOnlContext _context;
        public QuizRepository(CourseOnlContext context)
        {
            _context = context;
        }
        public async Task<int?> NumberOfQuizInChapterByCourseId(string courseId)
        {
            var quizCountByChapter = await (from chap in _context.Chapters
                                            join c in _context.Courses on chap.CourseId equals c.Id
                                            join q in _context.Quizzes on chap.Id equals q.ChapterId into quizGroup
                                            where c.Id == courseId
                                            select new
                                            {
                                                ChapterId = chap.Id,
                                                QuizCount = quizGroup.Count()
                                            })
                                        .ToListAsync();
            
            return quizCountByChapter.Sum(x => x.QuizCount); 
        }
    }
}