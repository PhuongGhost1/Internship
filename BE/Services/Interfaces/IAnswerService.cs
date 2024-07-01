using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BE.Dto.Answer;
using BE.Models;

namespace BE.Services.Interfaces
{
    public interface IAnswerService
    {
        Task<List<Answer>> GetAllDataOfAnswerFromQuizById(string quizId);


        //---------------------CRUD--------------------------//
        Task<List<Answer>> GetAllAnswers();
        Task<Answer?> CreateAnswer(string questionId, CreateAnswerDto createAnswerDto);
        Task<Answer?> UpdateAnswer(string answerId, UpdateAnswerDto updateAnswerDto);
        Task<bool> DeleteAnswer(string answerId);
    }
}