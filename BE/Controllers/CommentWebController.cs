using BE.Attributes;
using BE.Dto.Comment;
using BE.Dto.Message;
using BE.Models;
using BE.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BE.Controllers
{
    [ApiController]
    [Route("api/v1/web/comment")]
    public class CommentWebController
    {
        private readonly ICommentService _commentService;
        public CommentWebController(ICommentService commentService)
        {
            _commentService = commentService;
        }


        //---------------------CRUD--------------------------//
        [HttpGet]
        [Route("view-all-comments")]
        public async Task<List<Comment>> ViewAllComments()
        {
            return await _commentService.ViewAllComments();
        }

        // [CustomAuthorize("Student", "Instructor")]
        [HttpPost]
        [Route("create-comment")]
        public async Task<MessageDto> CreateComment([FromForm] CreateCommentDto createCommentDto)
        {
            Console.WriteLine(createCommentDto.CourseId);
            return await _commentService.CreateComment(createCommentDto);
        }

        [CustomAuthorize("Student", "Instructor")]
        [HttpPost]
        [Route("update-comment")]
        public async Task<Comment?> UpdateComment([FromForm] UpdateCommentDto updateCommentDto)
        {
            return await _commentService.UpdateComment(updateCommentDto);
        }

        [CustomAuthorize("Student", "Instructor")]
        [HttpPost]
        [Route("delete-comment")]
        public async Task<bool> DeleteComment([FromForm] CommentDto commentDto)
        {
            return await _commentService.DeleteComment(commentDto.CommentId);
        }

        [HttpPost, Route("get-comment-course")]
        public async Task<List<CommentCourseDto>> GetCommentByCourse([FromForm] string courseId)
        {
            return await _commentService.GetCommentByCourse(courseId);
        }
    }
}