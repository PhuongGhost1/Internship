using BE.Models;

namespace BE.Repository.Interface
{
    public interface IQuestionRepository
    {


        //---------------------CRUD--------------------------//
        Task<Question?> GetQuestionById(string questionId);
        Task<List<Question>> GetAllQuestions();
        Task<Question?> CreateQuestion(Question question);
        Task<Question?> UpdateQuestion(Question question);
        Task<bool> DeleteQuestion(string questionId);
    }
}