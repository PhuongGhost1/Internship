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
    }
}