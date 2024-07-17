namespace BE.Dto.Cart
{
    public class UpdateCartDTO
    {
        public string Id { get; set; }
        public string? UserId { get; set; }
        public DateTime? DateCreated { get; set; }
        public float? Total { get; set; }
        public int? Status { get; set; }
    }
}
