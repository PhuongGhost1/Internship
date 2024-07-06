using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BE.Models;
using BE.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace BE.Repository.Implementations
{
    public class AnswerRepository : IAnswerRepository
    {
        private readonly CourseOnlContext _context;
        public AnswerRepository(CourseOnlContext context)
        {
            _context = context;
        }

        public async Task<List<Answer>> GetAllDataOfAnswerFromQuizById(string quizId)
        {
            var answers = await
                        (from answer in _context.Answers
                        join question in _context.Questions on answer.QuestionId equals question.Id
                        join quiz in _context.Quizzes on question.QuizId equals quiz.Id
                        where quiz.Id == quizId
                        select answer)
                        .ToListAsync();
            return answers;
        }



        //---------------------CRUD--------------------------//

        public async Task<Answer?> GetAnswerById(string answerId)
        {
            return await _context.Answers.FirstOrDefaultAsync(ans => ans.Id == answerId);
        }

        public async Task<Answer?> CreateAnswer(Answer answer)
        {
            await _context.Answers.AddAsync(answer);
            await _context.SaveChangesAsync();
            return answer;
        }

        public async Task<bool> DeleteAnswer(string answerId)
        {
            var answer = await _context.Answers.FindAsync(answerId);

            if(answer == null) return false;

            answer.Status = 0;

            _context.Answers.Update(answer);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Answer>> GetAllAnswers()
        {
            return await _context.Answers.ToListAsync();
        }

        public async Task<Answer?> UpdateAnswer(Answer answer)
        {
            _context.Answers.Update(answer);
            await _context.SaveChangesAsync();
            return answer;
        }
    }
}