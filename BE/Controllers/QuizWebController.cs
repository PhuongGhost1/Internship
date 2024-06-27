using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BE.Dto.Course.Chapter.Quiz;
using BE.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BE.Controllers
{
    [Route("api/v1/web/quiz")]
    [ApiExplorerSettings(GroupName = "Web")]
    public class QuizWebController
    {
        private readonly IQuizService _quizService;
        public QuizWebController(IQuizService quizService)
        {
            _quizService = quizService;
        }

        [HttpGet]
        [Route("quiz-data/{courseId}")]
        public async Task<QuizDto> GetAllDataFromQuizByCourseId([FromRoute] string courseId){
            return await _quizService.GetAllDataFromQuizByCourseId(courseId);
        }
    }
}