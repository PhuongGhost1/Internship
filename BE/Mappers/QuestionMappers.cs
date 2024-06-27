using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BE.Dto.Course.Chapter.Quiz.Question;
using BE.Models;

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
    }
}