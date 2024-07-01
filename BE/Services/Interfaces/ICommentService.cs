using BE.Dto.Comment;
using BE.Models;

namespace BE.Services.Interfaces
{
    public interface ICommentService
    {
        

        //---------------------CRUD--------------------------//
        Task<List<Comment>> ViewAllComments();
        Task<Comment?> CreateComment(string userId, string courseId, CreateCommentDto createCommentDto);
        Task<Comment?> UpdateComment(string commentId, UpdateCommentDto updateCommentDto);
        Task<bool> DeleteComment(string commentId);
    }
}