using BE.Dto.Course.Chapter.Quiz;
using BE.Models;

namespace BE.Mappers
{
    public static class QuizMappers
    {
        public static QuizDto ToAllQuizDto(this Quiz quizModel){
            return new QuizDto{
                Id = quizModel.Id,
                Index = quizModel.Index,
                ChapterId = quizModel.ChapterId,
                Name = quizModel.Name,
                PassPercent = quizModel.PassPercent,
                CreateAt = quizModel.CreateAt,
                NumberQuestions = quizModel.NumberQuestions,
                TotalMark = quizModel.TotalMark,
                Status = quizModel.Status,
                Processings = quizModel.Processings.Select(p => p.ToProcessingData()).ToList(),
                Questions = quizModel.Questions.Select(q => q.ToQuestionData()).ToList(),
                Submissions = quizModel.Submissions.Select(s => s.ToSubmissionData()).ToList()
            };
        }
    }
}