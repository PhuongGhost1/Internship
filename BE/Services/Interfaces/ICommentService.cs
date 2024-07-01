using BE.Dto.Comment;
using BE.Models;

namespace BE.Services.Interfaces
{
    public interface ICommentService
    {
        

        //---------------------CRUD--------------------------//
        Task<List<Comment>> ViewAllComments();
        Task<Comment?> CreateComment(CreateCommentDto createCommentDto);
        Task<Comment?> UpdateComment(UpdateCommentDto updateCommentDto);
        Task<bool> DeleteComment(string commentId);
    }
}