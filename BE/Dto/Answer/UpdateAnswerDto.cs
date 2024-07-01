

namespace BE.Dto.Answer
{
    public class UpdateAnswerDto
    {
        public string? QuestionId { get; set; }
        public string? Text { get; set; }
        public bool? IsCorrect { get; set; }
    }
}