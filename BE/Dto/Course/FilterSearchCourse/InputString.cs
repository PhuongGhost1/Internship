namespace BE.Dto.Course.FilterSearchCourse
{
    public class InputString
    {
        public string? Query { get; set; }
        public string? Categories { get; set; }
        public string? PriceRange { get; set; }
        public string? Ratings { get; set; }
        public string? Levels { get; set; }
        public string? UserId { get; set; }
    }
}