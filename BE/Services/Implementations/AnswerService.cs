using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BE.Models;
using BE.Repository.Interface;
using BE.Services.Interfaces;

namespace BE.Services.Implementations
{
    public class AnswerService : IAnswerService
    {
        private readonly IAnswerRepository _answerRepo;
        private readonly IQuizRepository _quizRepo;
        public AnswerService(IAnswerRepository answerRepo, IQuizRepository quizRepo)
        {
            _answerRepo = answerRepo;
            _quizRepo = quizRepo;
        }

        public async Task<List<Answer>> GetAllDataOfAnswerFromQuizById(string quizId)
        {
            var quiz = await _quizRepo.GetDataOfQuizByQuizId(quizId);

            if(quiz == null) throw new Exception("Not found quiz!");

            var answers = await _answerRepo.GetAllDataOfAnswerFromQuizById(quizId);

            return answers;
        }
    }
}