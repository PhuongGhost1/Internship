using BE.Dto.Course.FilterSearchCourse.Item;

namespace BE.Dto.Course.FilterSearchCourse
{
    public class InputFilterSearchDto
    {
        public string? Query { get; set; }
        public List<string?>? Categories { get; set; }
        public List<int?>? PriceRange { get; set; }
        public List<RatingObj>? Ratings { get; set; }
        public List<LevelObj>? Levels { get; set; }
        public string? UserId { get; set; }
    }
}