namespace BE.Dto.Course.Chapter
{
    public class CreateChapterData
    {
        public string? CourseId { get; set; }
        public string? NameChapter { get; set; }
        public string? ItemsName { get; set; }
        public int? Index { get; set; }
    }
}