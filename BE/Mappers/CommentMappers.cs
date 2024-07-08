using BE.Dto.Comment;
using BE.Models;
using static BE.Utils.Utils;

namespace BE.Mappers
{
    public static class CommentMappers
    {
        public static Comment ToCreateCommentDto(this CreateCommentDto createCommentDto, string userId, string courseId){
            return new Comment{
                Id = GenerateIdModel("comment"),
                CreatedAt = GetTimeNow(),
                CourseId = courseId,
                UserId = userId,
                Rating = createCommentDto.Rating,
                Comment1 = createCommentDto.Comment
            };
        }

        public static Comment ToUpdateCommentDto(this UpdateCommentDto updateCommentDto){
            return new Comment{
                CreatedAt = GetTimeNow(),
                Rating = updateCommentDto.Rating,
                Comment1 = updateCommentDto.Comment
            };
        }
    }
}