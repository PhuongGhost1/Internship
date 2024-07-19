
using BE.Models;
using BE.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace BE.Repository.Implementations
{
    public class CommentRepository : ICommentRepository
    {
        private readonly CourseOnlContext _context;
        public CommentRepository(CourseOnlContext context)
        {
            _context = context;
        }


        //---------------------CRUD--------------------------//    
        public async Task CreateComment(Comment comment)
        {
            await _context.Comments.AddAsync(comment);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteComment(string commentId)
        {
            var comment = await _context.Comments.FindAsync(commentId);

            if (comment == null) return false;

            comment.IsVisible = true;

            _context.Comments.Update(comment);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Comment>> GetAllComments()
        {
            return await _context.Comments.ToListAsync();
        }

        public async Task<Comment?> GetCommentById(string commentId)
        {
            return await _context.Comments.FirstOrDefaultAsync(comment => comment.Id == commentId);
        }

        public async Task<Comment?> UpdateComment(Comment comment)
        {
            _context.Comments.Update(comment);
            await _context.SaveChangesAsync();
            return comment;
        }

        public async Task<List<Comment>> GetCommentsByCourse(string courseId)
        {
            return await _context.Comments.Include(c => c.User)
                                    .Where(c => c.CourseId == courseId && c.IsVisible == true)
                                    .ToListAsync();
        }
    }
}