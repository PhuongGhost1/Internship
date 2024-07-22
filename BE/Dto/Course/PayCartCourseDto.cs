namespace BE.Dto.Course
{
    public class PayCartCourseDto
    {
        public required List<string> CartCourseIds { get; set; }
        public required string UserId { get; set; }
    }
}