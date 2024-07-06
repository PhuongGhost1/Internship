namespace BE.Dto.User
{
    public class CreateUserData
    {
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Description { get; set; }
        public string? Phone { get; set; }
        public string? Role { get; set; }
    }
}