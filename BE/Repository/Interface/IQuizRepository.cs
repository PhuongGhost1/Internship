using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BE.Models;

namespace BE.Repository.Interface
{
    public interface IQuizRepository
    {
        Task<int?> NumberOfQuizInChapterByCourseId(string courseId);
        Task<Quiz?> GetAllDataFromQuizByCourseId(string courseId);
        Task<Quiz?> GetDataOfQuizByQuizId(string quizId);
        
        //---------------------CRUD--------------------------//
        Task<Quiz?> GetQuizById(string id);
        Task<Quiz?> CreateQuiz(Quiz quiz);
        Task<List<Quiz>> ViewAllQuizzes();
        Task<Quiz?> UpdateQuiz(Quiz quiz);
        Task<bool> DeleteQuiz(string quizId);
    }
}