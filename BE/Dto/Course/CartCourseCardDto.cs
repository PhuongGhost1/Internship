namespace BE.Dto.Course
{
    public class CartCourseCardDto
    {
        public List<BE.Models.Course> courses { get; set; }
        public string? imageUrl { get; set; }
    }
}