using BE.Models;

namespace BE.Dto.Course.Chapter.Quiz.Question
{
    public class QuestionDto
    {
        public string Id { get; set; } = null!;
        public string? QuizId { get; set; }
        public string? Text { get; set; }
        public int? Mark { get; set; }
        public bool? Type { get; set; }
        public DateTime? CreateAt { get; set; }
        public int? Status { get; set; }
        public List<BE.Models.Answer> Answers {get; set;} = new List<BE.Models.Answer>();
    }
}