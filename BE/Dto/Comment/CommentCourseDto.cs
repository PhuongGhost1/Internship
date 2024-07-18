namespace BE.Dto.Comment
{
    public class CommentCourseDto
    {
        public required Models.Comment Comment { get; set; }
        public string? UserImage { get; set; }
    }
}