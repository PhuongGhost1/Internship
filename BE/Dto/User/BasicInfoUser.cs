namespace BE.Dto.User
{
    public class BasicInfoUser
    {
        public string Id { get; set; } = null!;
        public string? Name { get; set; }
        public List<String> ListImage { get; set; } = null!;

        public string? Email { get; set; }

        public DateTime? DOB { get; set; }

        public String? Gender { get; set; }

    }
}