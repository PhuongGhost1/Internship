using BE.Dto.Comment;
using BE.Mappers;
using BE.Models;
using BE.Repository.Interface;
using BE.Services.Interfaces;

namespace BE.Services.Implementations
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepo;
        private readonly IUserRepository _userRepo;
        private readonly ICourseRepository _courseRepo;
        public CommentService(ICommentRepository commentRepo, IUserRepository userRepo, ICourseRepository courseRepo)
        {
            _commentRepo = commentRepo;
            _userRepo = userRepo;
            _courseRepo = courseRepo;
        }


        //---------------------CRUD--------------------------//
        public async Task<Comment?> CreateComment(CreateCommentDto createCommentDto)
        {
            var user = await _userRepo.GetUserById(createCommentDto.UserId);

            if(user == null) throw new Exception("Unable to find user!");

            var course = await _courseRepo.RetriveCourseInformationById(createCommentDto.UserId);

            if(course == null) throw new Exception("Unable to find course!");

            var createComment = createCommentDto.ToCreateCommentDto(createCommentDto.UserId, createCommentDto.CourseId);

            if(createComment == null) throw new Exception("Unable to create comment");

            return await _commentRepo.CreateComment(createComment);
        }

        public async Task<bool> DeleteComment(string commentId)
        {
            var comment = await _commentRepo.GetCommentById(commentId);

            if(comment == null) throw new Exception("Unable to find comment!");

            return await _commentRepo.DeleteComment(commentId);
        }

        public async Task<Comment?> UpdateComment(UpdateCommentDto updateCommentDto)
        {
            var comment = await _commentRepo.GetCommentById(updateCommentDto.CommentId);

            if(comment == null) throw new Exception("Unable to find comment!");

            var updateComment = updateCommentDto.ToUpdateCommentDto();

            if(updateComment == null) throw new Exception("Unable to update comment!");

            return await _commentRepo.UpdateComment(updateComment);
        }

        public async Task<List<Comment>> ViewAllComments()
        {
            return await _commentRepo.GetAllComments();
        }

    }
}