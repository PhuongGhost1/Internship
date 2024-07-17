namespace BE.Dto.Feedback
{
    public class CreateFeedbackDTO
    {
        public string? UserId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public bool? IsRead { get; set; }
    }
}
