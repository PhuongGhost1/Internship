using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BE.Attributes;
using BE.Dto.Answer;
using BE.Models;
using BE.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
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

        [CustomAuthorize("Student", "Instructor")]
        [HttpGet]
        [Route("answer-data")]
        public async Task<List<Answer>> GetAllDataOfAnswerFromQuizById([FromForm] AnswerDto answerDto){
            return await _answerService.GetAllDataOfAnswerFromQuizById(answerDto);
        }


        //---------------------CRUD--------------------------//
        [CustomAuthorize("Student", "Instructor")]
        [HttpGet]
        [Route("view-all-answers")]
        public async Task<List<Answer>> ViewAllAnswers(){
            return await _answerService.GetAllAnswers();
        }

        [CustomAuthorize("Student", "Instructor")]
        [HttpPost]
        [Route("create-answer")]
        public async Task<Answer?> CreateAnswer([FromForm] CreateAnswerDto createAnswerDto){
            return await _answerService.CreateAnswer(createAnswerDto);
        }

        [CustomAuthorize("Student", "Instructor")]
        [HttpPost]
        [Route("update-answer")]
        public async Task<Answer?> UpdateAnswer([FromForm] UpdateAnswerDto updateAnswerDto){
            return await _answerService.UpdateAnswer(updateAnswerDto);
        }

        [CustomAuthorize("Student", "Instructor")]
        [HttpPost]
        [Route("delete-answer")]
        public async Task<bool> DeleteAnswer([FromForm] AnswerDto answerDto){
            return await _answerService.DeleteAnswer(answerDto.AnswerId);
        }
    }
}