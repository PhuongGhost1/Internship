
namespace BE.Dto.Course.Chapter.Quiz
{
    public class SubmissionDto
    {
        public string? Id { get; set; }
        public string? QuizId { get; set; }
        public string? UserId { get; set; }
        public double? Grade { get; set; }
        public DateTime? Date { get; set; }
        public bool? IsPass { get; set; }
    }
}