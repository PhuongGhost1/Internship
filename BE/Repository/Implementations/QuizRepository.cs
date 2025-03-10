using BE.Models;
using BE.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace BE.Repository.Implementations
{
    public class QuizRepository : IQuizRepository
    {
        private readonly CourseOnlContext _context;
        public QuizRepository(CourseOnlContext context)
        {
            _context = context;
        }

        public async Task<Quiz?> GetAllDataFromQuizByCourseId(string courseId)
        {
            var allDataFromQuiz = await
                                    (from quiz in _context.Quizzes
                                     join chap in _context.Chapters on quiz.ChapterId equals chap.Id
                                     join course in _context.Courses on chap.CourseId equals course.Id
                                     join question in _context.Questions on quiz.Id equals question.QuizId
                                     join submission in _context.Submissions on quiz.Id equals submission.QuizId
                                     join processing in _context.Processings on quiz.Id equals processing.QuizId
                                     where course.Id == courseId
                                     select quiz)
                                    .Include(q => q.Processings)
                                    .Include(q => q.Questions)
                                    .Include(q => q.Submissions)
                                    .FirstOrDefaultAsync();
            return allDataFromQuiz;
        }

        public async Task<Quiz?> GetDataOfQuizByQuizId(string quizId)
        {
            return await _context.Quizzes.FirstOrDefaultAsync(q => q.Id == quizId);
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


        //---------------------CRUD--------------------------//
        public async Task<Quiz?> GetQuizById(string id)
        {
            return await _context.Quizzes.FirstOrDefaultAsync(q => q.Id == id);
        }

        public async Task<Quiz?> CreateQuiz(Quiz quiz)
        {
            await _context.Quizzes.AddAsync(quiz);
            await _context.SaveChangesAsync();
            return quiz;
        }

        public async Task<bool> DeleteQuiz(string quizId)
        {
            var quiz = await _context.Quizzes.FindAsync(quizId);

            if(quiz == null) return false;

            quiz.Status = 0;

            _context.Quizzes.Update(quiz);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<List<Quiz>> ViewAllQuizzes()
        {
            return await _context.Quizzes.ToListAsync();
        }

        public async Task<Quiz?> UpdateQuiz(Quiz quiz)
        {
            _context.Quizzes.Update(quiz);
            await _context.SaveChangesAsync();
            return quiz;
        }
    }
}