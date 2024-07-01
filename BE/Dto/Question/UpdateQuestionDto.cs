using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BE.Dto.Question
{
    public class UpdateQuestionDto
    {
        public string? QuestionId {get; set;}
        public string? QuizId { get; set; }
        public string? Text { get; set; }
        public int? Mark { get; set; }
        public bool? Type { get; set; }
    }
}