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
        [Route("create-comment")]
        public async Task<Comment?> CreateComment([FromBody] CreateCommentDto createCommentDto){
            return await _commentService.CreateComment(createCommentDto);
        }

        [HttpPost]
        [Route("update-comment")]
        public async Task<Comment?> UpdateComment([FromBody] UpdateCommentDto updateCommentDto){
            return await _commentService.UpdateComment(updateCommentDto);
        }

        [HttpPost]
        [Route("delete-comment")]
        public async Task<bool> DeleteComment([FromBody] CommentDto commentDto){
            return await _commentService.DeleteComment(commentDto.CommentId);
        }
    }
}