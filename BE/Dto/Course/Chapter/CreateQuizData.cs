namespace BE.Dto.Course.Chapter
{
    public class CreateQuizData
    {
        public string? QuizId { get; set; }
        public string? Question { get; set; }
        public string? Answers { get; set; }
        public bool? Type { get; set; }
    }
}