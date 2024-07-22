
using BE.Models;

namespace BE.Repository.Interface
{
    public interface ICommentRepository
    {


        //---------------------CRUD--------------------------//
        Task<Comment?> GetCommentById(string commentId);
        Task<List<Comment>> GetAllComments();
        Task CreateComment(Comment comment);
        Task<bool> DeleteComment(string commentId);
        Task<Comment?> UpdateComment(Comment comment);
        Task<List<Comment>> GetCommentsByCourse(string courseId);
    }
}