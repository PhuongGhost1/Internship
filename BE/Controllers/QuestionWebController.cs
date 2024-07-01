using BE.Dto.Question;
using BE.Models;
using BE.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BE.Controllers
{
    [ApiController]
    [Route("api/v1/web/question")]
    public class QuestionWebController 
    {
        private readonly IQuestionService _quesService;
        public QuestionWebController(IQuestionService quesService)
        {
            _quesService = quesService;
        }



        //---------------------CRUD--------------------------//
        [HttpGet]
        [Route("view-all-questions")]
        public async Task<List<Question>> ViewAllQuestions(){
            return await _quesService.GetAllQuestions();
        }

        [HttpPost]
        [Route("create-question/{quizId}")]
        public async Task<Question?> CreateQuestion([FromRoute] string quizId, [FromBody] CreateQuestionDto createQuestionDto){
            return await _quesService.CreateQuestion(createQuestionDto, quizId);
        }

        [HttpPost]
        [Route("update-question/{questionId}")]
        public async Task<Question?> UpdateQuestion([FromRoute] string questionId, [FromBody] UpdateQuestionDto updateQuestionDto){
            return await _quesService.UpdateQuestion(questionId, updateQuestionDto);
        }

        [HttpPost]
        [Route("delete-question/{questionId}")]
        public async Task<bool> DeleteQuestion([FromRoute] string questionId){
            return await _quesService.DeleteQuestion(questionId);
        }
    }
}