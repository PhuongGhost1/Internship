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
        [Route("answer-data")]
        public async Task<List<Answer>> GetAllDataOfAnswerFromQuizById([FromBody] AnswerDto answerDto){
            return await _answerService.GetAllDataOfAnswerFromQuizById(answerDto);
        }


        //---------------------CRUD--------------------------//
        [HttpGet]
        [Route("view-all-answers")]
        public async Task<List<Answer>> ViewAllAnswers(){
            return await _answerService.GetAllAnswers();
        }

        [HttpPost]
        [Route("create-answer")]
        public async Task<Answer?> CreateAnswer([FromBody] CreateAnswerDto createAnswerDto){
            return await _answerService.CreateAnswer(createAnswerDto);
        }

        [HttpPost]
        [Route("update-answer")]
        public async Task<Answer?> UpdateAnswer([FromBody] UpdateAnswerDto updateAnswerDto){
            return await _answerService.UpdateAnswer(updateAnswerDto);
        }

        [HttpPost]
        [Route("delete-answer")]
        public async Task<bool> DeleteAnswer([FromBody] AnswerDto answerDto){
            return await _answerService.DeleteAnswer(answerDto.AnswerId);
        }
    }
}