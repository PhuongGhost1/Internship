using BE.Dto.Course.Chapter.Quiz;
using BE.Repository.Interface;

namespace BE.Services.Interfaces
{
    public interface IQuizService
    {
        Task<QuizDto> GetAllDataFromQuizByCourseId(string courseId);
    }
}