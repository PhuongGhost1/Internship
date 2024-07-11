using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BE.Dto.Course.Chapter.Quiz.Question;
using BE.Dto.Processing;

namespace BE.Dto.Course.Chapter.Quiz
{
    public class QuizDto
    {
        public string? Id { get; set; }
        public int? Index { get; set; }
        public string? ChapterId { get; set; }
        public string? Name { get; set; }
        public int? PassPercent { get; set; }
        public DateTime? CreateAt { get; set; }
        public int? NumberQuestions { get; set; }
        public int? TotalMark { get; set; }
        public int? Status { get; set; }
        public List<ProcessingDto> Processings { get; set; } = new List<ProcessingDto>();
        public List<QuestionDto> Questions { get; set; } = new List<QuestionDto>();
        public List<SubmissionDto> Submissions { get; set; } = new List<SubmissionDto>();
    }
}