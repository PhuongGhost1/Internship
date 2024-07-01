using BE.Dto.Course.Chapter.Quiz;
using BE.Dto.Quiz;
using BE.Models;
using BE.Repository.Interface;

namespace BE.Services.Interfaces
{
    public interface IQuizService
    {
        Task<QuizDto> GetAllDataFromQuizByCourseId(string courseId);
        
        //---------------------CRUD--------------------------//
        Task<Quiz?> CreateQuiz(CreateQuizDto createQuizDto, string chapterId);
        Task<List<Quiz>> ViewAllQuizzes();
        Task<Quiz?> UpdateQuiz(string quizId, UpdateQuizDto updateQuizDto);
        Task<bool> DeleteQuiz(string quizId); 
    }
}