namespace BE.Dto.Course
{
    public class SaveCourseCard
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public int? CountLecture { get; set; }
        public string? Level { get; set; }
        public float? RatingAvg { get; set; }
        public int? RatingCount { get; set; }
        public List<BE.Models.Category>? Categories { get; set; }
        public string? ImgUrl { get; set; }
    }
}