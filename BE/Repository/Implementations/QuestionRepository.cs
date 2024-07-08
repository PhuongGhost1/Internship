using BE.Models;
using BE.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace BE.Repository.Implementations
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly CourseOnlContext _context;
        public QuestionRepository(CourseOnlContext context)
        {
            _context = context;
        }


        //---------------------CRUD--------------------------//
        public async Task<Question?> CreateQuestion(Question question)
        {
            await _context.Questions.AddAsync(question);
            await _context.SaveChangesAsync();
            return question;
        }

        public async Task<bool> DeleteQuestion(string questionId)
        {
            var question = await _context.Questions.FindAsync(questionId);

            if(question == null) return false;

            question.Status = 0;

            _context.Questions.Update(question);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Question>> GetAllQuestions()
        {
            return await _context.Questions.ToListAsync();
        }

        public async Task<Question?> GetQuestionById(string questionId)
        {
            return await _context.Questions.FirstOrDefaultAsync(ques => ques.Id == questionId);
        }

        public async Task<Question?> UpdateQuestion(Question question)
        {
            _context.Questions.Update(question);
            await _context.SaveChangesAsync();
            return question;
        }
    }
}