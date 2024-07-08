using BE.Dto.Course.Chapter.Quiz.Question;
using BE.Dto.Question;
using BE.Models;
using static BE.Utils.Utils;

namespace BE.Mappers
{
    public static class QuestionMappers
    {
        public static QuestionDto ToQuestionData(this Question questionModel){
            return new QuestionDto{
                Id = questionModel.Id,
                QuizId = questionModel.QuizId,
                Text = questionModel.Text,
                Mark = questionModel.Mark,
                Type = questionModel.Type,
                CreateAt = questionModel.CreateAt,
                Status = questionModel.Status
            };
        }

        public static Question ToCreataQuestionDto(this CreateQuestionDto createQuestionDto, string quizId){
            return new Question{
                Id = GenerateIdModel("question"),
                QuizId = quizId,
                Text = createQuestionDto.Text,
                Mark = createQuestionDto.Mark,
                Type = createQuestionDto.Type,
                CreateAt = GetTimeNow()
            };
        }

        public static Question ToUpdateQuestionDto(this UpdateQuestionDto updateQuestionDto){
            return new Question{
                QuizId = updateQuestionDto.QuizId,
                Text = updateQuestionDto.Text,
                Mark = updateQuestionDto.Mark,
                Type = updateQuestionDto.Type,
                CreateAt = GetTimeNow()
            };
        }
    }
}