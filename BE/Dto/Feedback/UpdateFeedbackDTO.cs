namespace BE.Dto.Feedback
{
    public class UpdateFeedbackDTO
    {
        public string Id { get; set; } = null!;
        public string? UserId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public bool? IsRead { get; set; }
    }
}
