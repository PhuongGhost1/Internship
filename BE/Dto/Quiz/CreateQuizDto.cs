
namespace BE.Dto.Quiz
{
    public class CreateQuizDto
    {
        public string? ChapId {get; set;}
        public int? Index { get; set; }
        public string? Name { get; set; }
        public int? PassPercent { get; set; }
        public int? NumberQuestions { get; set; }
        public int? TotalMark { get; set; }
    }
}