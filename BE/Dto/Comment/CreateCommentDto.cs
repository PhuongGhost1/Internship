
namespace BE.Dto.Comment
{
    public class CreateCommentDto
    {
        public string? UserId {get; set;}
        public string? CourseId {get; set;}
        public int? Rating { get; set; }
        public string? Comment { get; set; }
    }
}