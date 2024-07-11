using BE.Dto.Question;
using BE.Models;

namespace BE.Services.Interfaces
{
    public interface IQuestionService
    {
        

        //---------------------CRUD--------------------------//
        Task<List<Question>> GetAllQuestions();
        Task<Question?> CreateQuestion(CreateQuestionDto createQuestionDto, string quizId);
        Task<Question?> UpdateQuestion(string questionId, UpdateQuestionDto updateQuestionDto);
        Task<bool> DeleteQuestion(string questionId);
    }
}