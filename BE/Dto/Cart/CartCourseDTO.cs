using BE.Dto.Course;

namespace BE.Dto.Cart
{
    public class CartCourseDTO
    {
        public CartDTO? Cart { get; set; }
        public CourseForCartDto? Course { get; set; }
    }
}
