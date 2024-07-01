using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BE.Dto.Answer;
using BE.Mappers;
using BE.Models;
using BE.Repository.Interface;
using BE.Services.Interfaces;

namespace BE.Services.Implementations
{
    public class AnswerService : IAnswerService
    {
        private readonly IAnswerRepository _answerRepo;
        private readonly IQuizRepository _quizRepo;
        private readonly IQuestionRepository _quesRepo;
        public AnswerService(IAnswerRepository answerRepo, IQuizRepository quizRepo, IQuestionRepository quesRepo)
        {
            _answerRepo = answerRepo;
            _quizRepo = quizRepo;
            _quesRepo = quesRepo;
        }

        public async Task<List<Answer>> GetAllDataOfAnswerFromQuizById(string quizId)
        {
            var quiz = await _quizRepo.GetDataOfQuizByQuizId(quizId);

            if(quiz == null) throw new Exception("Not found quiz!");

            var answers = await _answerRepo.GetAllDataOfAnswerFromQuizById(quizId);

            return answers;
        }



        //---------------------CRUD--------------------------//
        public async Task<Answer?> CreateAnswer(string questionId, CreateAnswerDto createAnswerDto)
        {
            var question = await _quesRepo.GetQuestionById(questionId);

            if(question == null) throw new Exception("Unable to find question!");

            var createAnswer = createAnswerDto.ToCreateAnswerDto(questionId);

            if(createAnswer == null) throw new Exception("Unable to create question!");

            return await _answerRepo.CreateAnswer(createAnswer);
        }

        public async Task<bool> DeleteAnswer(string answerId)
        {
            var answer = await _answerRepo.GetAnswerById(answerId);

            if(answer == null) throw new Exception("Unable to find answer");

            return await _answerRepo.DeleteAnswer(answerId);
        }

        public async Task<List<Answer>> GetAllAnswers()
        {
            return await _answerRepo.GetAllAnswers();
        }

        public async Task<Answer?> UpdateAnswer(string answerId, UpdateAnswerDto updateAnswerDto)
        {
            var answer = await _answerRepo.GetAnswerById(answerId);

            if(answer == null) throw new Exception("Unable to find answer!");

            var updateAnswer = updateAnswerDto.ToUpdateAnswerDto();

            if(updateAnswer == null) throw new Exception("Unable to update answer!");

            return await _answerRepo.UpdateAnswer(updateAnswer);
        }
    }
}