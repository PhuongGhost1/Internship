using BE.Dto.Comment;
using BE.Dto.Message;
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
        public async Task<MessageDto> CreateComment(CreateCommentDto createCommentDto)
        {
            var user = await _userRepo.GetUserById(createCommentDto.UserId);

            if (user == null)
                return new MessageDto
                {
                    Message = "user is null",
                    Status = 0,
                };

            var course = await _courseRepo.RetriveCourseInformationById(createCommentDto.CourseId);

            if (course == null)
                return new MessageDto
                {
                    Message = "course is null",
                    Status = 0,
                };

            var createComment = createCommentDto.ToCreateCommentDto();

            if (createComment == null)
                return new MessageDto
                {
                    Message = "create course is null",
                    Status = 0,
                };

            await _commentRepo.CreateComment(createComment);
            return new MessageDto
            {
                Message = "Create Message Success",
                Status = 1,
            };
        }

        public async Task<bool> DeleteComment(string commentId)
        {
            var comment = await _commentRepo.GetCommentById(commentId);

            if (comment == null) throw new Exception("Unable to find comment!");

            return await _commentRepo.DeleteComment(commentId);
        }

        public async Task<Comment?> UpdateComment(UpdateCommentDto updateCommentDto)
        {
            var comment = await _commentRepo.GetCommentById(updateCommentDto.CommentId);

            if (comment == null) throw new Exception("Unable to find comment!");

            var updateComment = updateCommentDto.ToUpdateCommentDto();

            if (updateComment == null) throw new Exception("Unable to update comment!");

            return await _commentRepo.UpdateComment(updateComment);
        }

        public async Task<List<Comment>> ViewAllComments()
        {
            return await _commentRepo.GetAllComments();
        }

        public async Task<List<CommentCourseDto>> GetCommentByCourse(string courseId)
        {
            var commentCourses = new List<CommentCourseDto>();

            var comments = (await _commentRepo.GetCommentsByCourse(courseId)).OrderByDescending(c => c.CreatedAt);

            foreach (var comment in comments)
            {
                Console.WriteLine(comment.UserId);
                string? userImage = await _userRepo.GetImageUser(comment.UserId);

                commentCourses.Add(new CommentCourseDto
                {
                    Comment = comment,
                    UserImage = userImage
                });
            }

            return commentCourses;
        }
    }
}