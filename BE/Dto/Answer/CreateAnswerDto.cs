
namespace BE.Dto.Answer
{
    public class CreateAnswerDto
    {
        public string? QuestionId {get; set;}
        public string? Text { get; set; }
        public bool? IsCorrect { get; set; }
    }
}