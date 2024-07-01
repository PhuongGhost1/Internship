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

        [HttpPost]
        [Route("quiz-data")]
        public async Task<QuizDto> GetAllDataFromQuizByCourseId([FromForm] string courseId){
            return await _quizService.GetAllDataFromQuizByCourseId(courseId);
        }


        //---------------------CRUD--------------------------//
        [HttpGet]
        [Route("view-all-quizzes")]
        public async Task<List<Quiz>> ViewAllQuizzes(){
            return await _quizService.ViewAllQuizzes();
        }


        [HttpPost]
        [Route("create-quiz")]
        public async Task<Quiz?> CreateQuiz([FromBody] CreateQuizDto createQuizDto){
            return await _quizService.CreateQuiz(createQuizDto, createQuizDto.ChapId);
        }

        [HttpPost]
        [Route("update-quiz")]
        public async Task<Quiz?> UpdateQuiz([FromForm] string quizId, [FromBody] UpdateQuizDto updateQuizDto){
            return await _quizService.UpdateQuiz(quizId, updateQuizDto);
        }

        [HttpPost]
        [Route("delete-quiz")]
        public async Task<bool> DeleteQuiz([FromForm] string quizId){
            return await _quizService.DeleteQuiz(quizId); 
        }
    }
}