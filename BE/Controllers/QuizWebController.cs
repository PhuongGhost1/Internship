using BE.Dto.Course.Chapter.Quiz;
using BE.Dto.Quiz;
using BE.Models;
using BE.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BE.Controllers
{
    [Route("api/v1/web/quiz")]
    [ApiController]
    public class QuizWebController
    {
        private readonly IQuizService _quizService;
        public QuizWebController(IQuizService quizService)
        {
            _quizService = quizService;
        }

        [HttpGet]
        [Route("quiz-data/{courseId}")]
        public async Task<QuizDto> GetAllDataFromQuizByCourseId([FromRoute] string courseId)
        {
            return await _quizService.GetAllDataFromQuizByCourseId(courseId);
        }


        //---------------------CRUD--------------------------//
        [HttpGet]
        [Route("view-all-quizzes")]
        public async Task<List<Quiz>> ViewAllQuizzes(){
            return await _quizService.ViewAllQuizzes();
        }


        [HttpPost]
        [Route("create-quiz/{chapterId}")]
        public async Task<Quiz?> CreateQuiz([FromRoute] string chapterId, [FromBody] CreateQuizDto createQuizDto){
            return await _quizService.CreateQuiz(createQuizDto, chapterId);
        }

        [HttpPost]
        [Route("update-quiz/{quizId}")]
        public async Task<Quiz?> UpdateQuiz([FromRoute] string quizId, [FromBody] UpdateQuizDto updateQuizDto){
            return await _quizService.UpdateQuiz(quizId, updateQuizDto);
        }

        [HttpPost]
        [Route("delete-quiz/{quizId}")]
        public async Task<bool> DeleteQuiz([FromRoute] string quizId){
            return await _quizService.DeleteQuiz(quizId); 
        }
    }
}