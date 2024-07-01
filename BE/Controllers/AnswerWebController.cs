using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BE.Dto.Answer;
using BE.Models;
using BE.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BE.Controllers
{
    [Route("api/v1/web/answer")]
    [ApiController]
    public class AnswerWebController
    {
        private readonly IAnswerService _answerService;
        public AnswerWebController(IAnswerService answerService)
        {
            _answerService = answerService;
        }

        [HttpGet]
        [Route("answer-data/{quizId}")]
        public async Task<List<Answer>> GetAllDataOfAnswerFromQuizById([FromRoute] string quizId)
        {
            return await _answerService.GetAllDataOfAnswerFromQuizById(quizId);
        }


        //---------------------CRUD--------------------------//
        [HttpGet]
        [Route("view-all-answers")]
        public async Task<List<Answer>> ViewAllAnswers(){
            return await _answerService.GetAllAnswers();
        }

        [HttpPost]
        [Route("create-answer/{questionId}")]
        public async Task<Answer?> CreateAnswer([FromRoute] string questionId, [FromBody] CreateAnswerDto createAnswerDto){
            return await _answerService.CreateAnswer(questionId, createAnswerDto);
        }

        [HttpPost]
        [Route("update-answer/{answerId}")]
        public async Task<Answer?> UpdateAnswer([FromRoute] string answerId, [FromBody] UpdateAnswerDto updateAnswerDto){
            return await _answerService.UpdateAnswer(answerId, updateAnswerDto);
        }

        [HttpPost]
        [Route("delete-answer/{answerId}")]
        public async Task<bool> DeleteAnswer([FromRoute] string answerId){
            return await _answerService.DeleteAnswer(answerId);
        }
    }
}