using BE.Models;

namespace BE.Repository.Interface
{
    public interface IAnswerRepository
    {
        Task<List<Answer>> GetAllDataOfAnswerFromQuizById(string quizId);


        //---------------------CRUD--------------------------//
        Task<Answer?> GetAnswerById(string answerId);
        Task<List<Answer>> GetAllAnswers();
        Task<Answer?> CreateAnswer(Answer answer);
        Task<Answer?> UpdateAnswer(Answer answer);
        Task<bool> DeleteAnswer(string answerId);
    }
}