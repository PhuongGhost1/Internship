using BE.Dto.Course;

namespace BE.Dto.Cart
{
    public class CartCourseDTO
    {
        public string? CartCourseId {get; set;}
        public CartDTO? Cart { get; set; }
        public CourseForCartDto? Course { get; set; }
    }
}
