namespace BE.Dto.Course.FilterSearchCourse
{
    public class OutputFilterSearchDto
    {
        public string? CourseId { get; set; }
        public string? CourseImg { get; set; }
        public string? CourseName { get; set; }
        public string? CourseLevel { get; set; }
        public int? LectureCount { get; set; }
        public TimeSpan? TimeTotal { get; set; }
        public float? RatingAVG { get; set; }
        public int? RatingCount { get; set; }
        public int? StudentCount { get; set; }
        public float? Price { get; set; }
        public bool IsSaved { get; set; }
        public string? InstructorName { get; set; }
        public string? InstructorImg { get; set; }
    }
}