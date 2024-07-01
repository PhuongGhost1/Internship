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
        Task<List<Answer>> GetAllDataOfAnswerFromQuizById(AnswerDto answerDto);


        //---------------------CRUD--------------------------//
        Task<List<Answer>> GetAllAnswers();
        Task<Answer?> CreateAnswer(CreateAnswerDto createAnswerDto);
        Task<Answer?> UpdateAnswer(UpdateAnswerDto updateAnswerDto);
        Task<bool> DeleteAnswer(string answerId);
    }
}