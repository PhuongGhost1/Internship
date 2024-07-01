using BE.Dto.Course.Chapter.Quiz;
using BE.Dto.Quiz;
using BE.Models;
using static BE.Utils.Utils;

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


        //---------------------CRUD--------------------------//
        public static Quiz ToCreateQuizDto(this CreateQuizDto createQuizDto, string chapId){
            return new Quiz{
                Id = GenerateIdModel("quiz"),
                ChapterId = chapId,
                Name = createQuizDto.Name,
                PassPercent = createQuizDto.PassPercent,
                NumberQuestions = createQuizDto.NumberQuestions,
                TotalMark = createQuizDto.TotalMark,
                CreateAt = GetTimeNow()
            };
        }

        public static Quiz ToUpdateQuizDto(this UpdateQuizDto updateQuizDto){
            return new Quiz{
                ChapterId = updateQuizDto.ChapterId,
                Name = updateQuizDto.Name,
                PassPercent = updateQuizDto.PassPercent,
                NumberQuestions = updateQuizDto.NumberQuestions,
                TotalMark = updateQuizDto.TotalMark,
                CreateAt = GetTimeNow()
            };
        }
    }
}