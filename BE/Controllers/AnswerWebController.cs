using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BE.Models;
using BE.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BE.Controllers
{
    [Route("api/v1/web/answer")]
    [ApiExplorerSettings]
    public class AnswerWebController
    {
        private readonly IAnswerService _answerService;
        public AnswerWebController(IAnswerService answerService)
        {
            _answerService = answerService;   
        }

        [HttpGet]
        [Route("answer-data/{quizId}")]
        public async Task<List<Answer>> GetAllDataOfAnswerFromQuizById([FromRoute] string quizId){
            return await _answerService.GetAllDataOfAnswerFromQuizById(quizId);
        }
    }
}