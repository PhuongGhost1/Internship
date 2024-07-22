namespace BE.Dto.Course
{
    public class CartDto
    {
        public string? cartId { get; set; }
        public List<CartCourseCardDto> CourseCart { get; set; }
    }
}