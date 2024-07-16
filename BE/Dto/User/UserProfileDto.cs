namespace BE.Dto.User
{
    public class UserProfileDto
    {
        public required string UserId { get; set; }
        public IFormFile? Image { get; set; }
        public required string Name { get; set; }
        public required string Username { get; set; }
        public required DateTime DOB { get; set; }
        public required string Description { get; set; }
        public required string Gender { get; set; }
    }
}