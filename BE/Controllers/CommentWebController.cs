using BE.Dto.Comment;
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
        public async Task<List<Comment>> ViewAllComments(){
            return await _commentService.ViewAllComments();
        }

        [HttpPost]
        [Route("create-comment/{userId}&{courseId}")]
        public async Task<Comment?> CreateComment([FromRoute] string userId, [FromRoute] string courseId, [FromBody] CreateCommentDto createCommentDto){
            return await _commentService.CreateComment(userId, courseId, createCommentDto);
        }

        [HttpPost]
        [Route("update-comment/{commentId}")]
        public async Task<Comment?> UpdateComment([FromRoute] string commentId, [FromBody] UpdateCommentDto updateCommentDto){
            return await _commentService.UpdateComment(commentId, updateCommentDto);
        }

        [HttpPost]
        [Route("delete-comment/{commentId}")]
        public async Task<bool> DeleteComment([FromRoute] string commentId){
            return await _commentService.DeleteComment(commentId);
        }
    }
}