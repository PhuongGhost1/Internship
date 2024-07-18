using BE.Dto.Comment;
using BE.Dto.Message;
using BE.Models;

namespace BE.Services.Interfaces
{
    public interface ICommentService
    {


        //---------------------CRUD--------------------------//
        Task<List<Comment>> ViewAllComments();
        Task<MessageDto> CreateComment(CreateCommentDto createCommentDto);
        Task<Comment?> UpdateComment(UpdateCommentDto updateCommentDto);
        Task<bool> DeleteComment(string commentId);
        Task<List<CommentCourseDto>> GetCommentByCourse(string courseId);
    }
}