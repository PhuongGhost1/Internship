using BE.Dto.Answer;
using BE.Models;
using static BE.Utils.Utils;

namespace BE.Mappers
{
    public static class AnswerMappers
    {
        public static Answer ToCreateAnswerDto(this CreateAnswerDto createAnswerDto, string questionId){
            return new Answer{
                Id = GenerateIdModel("answer"),
                CreatedAt = GetTimeNow(),
                QuestionId = questionId,
                Text = createAnswerDto.Text,
                IsCorrect = createAnswerDto.IsCorrect
            };
        }

        public static Answer ToUpdateAnswerDto(this UpdateAnswerDto updateAnswerDto){
            return new Answer{
                CreatedAt = GetTimeNow(),
                QuestionId = updateAnswerDto.QuestionId,
                Text = updateAnswerDto.Text,
                IsCorrect = updateAnswerDto.IsCorrect
            };
        }
    }
}