using BE.Attributes;
using BE.Dto.Follow;
using BE.Models;
using BE.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BE.Controllers
{
    [ApiController]
    [Route("api/v1/web/follow")]
    public class FollowWebController 
    {
        private readonly IFollowService _followService;
        public FollowWebController(IFollowService followService)
        {
            _followService = followService;
        }


        //---------------------CRUD--------------------------//
        [CustomAuthorize("Student", "Instructor")]
        [HttpGet]
        [Route("view-all-follows")]
        public async Task<List<Follow>> ViewAllFollows(){
            return await _followService.ViewAllFollows();
        }

        [CustomAuthorize("Student", "Instructor")]
        [HttpPost]
        [Route("create-follow")]
        public async Task<Follow?> CreateFollow([FromForm] CreateFollowDto createFollowDto){
            return await _followService.CreateFollow (createFollowDto);
        }

        [CustomAuthorize("Student", "Instructor")]
        [HttpPost]
        [Route("update-follow")]
        public async Task<Follow?> UpdateFollow([FromForm] string followId, [FromForm] UpdateFollowDto updateFollowDto){
            return await _followService.UpdateFollow(followId, updateFollowDto);
        }

        [CustomAuthorize("Student", "Instructor")]
        [HttpPost]
        [Route("delete-follow")]
        public async Task<bool> DeleteFollow([FromForm] string followId){
            return await _followService.DeleteFollow(followId);
        }
    }
}
