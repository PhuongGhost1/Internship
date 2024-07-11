using BE.Attributes;
using BE.Dto.RoleUser;
using BE.Models;
using BE.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BE.Controllers
{
    [ApiController]
    [Route("api/v1/web/role-user")]
    public class RoleUserWebController 
    {
        private readonly IRoleUserService _roleUserService;
        public RoleUserWebController(IRoleUserService roleUserService)
        {
            _roleUserService = roleUserService;
        }


        //---------------------CRUD--------------------------//
        [CustomAuthorize("Super Admin")]
        [HttpGet]
        [Route("view-all-roleUsers")]
        public async Task<List<RoleUser>> ViewAllRoleUsers(){
            return await _roleUserService.ViewAllRoleUsers();
        }

        [CustomAuthorize("Super Admin")]
        [HttpPost]
        [Route("create-roleUser")]
        public async Task<RoleUser?> CreateRoleUser([FromForm] CreateRoleUserDto createRoleUserDto){
            return await _roleUserService.CreateRoleUser(createRoleUserDto);
        }

        [CustomAuthorize("Super Admin")]
        [HttpPost]
        [Route("update-roleUser")]
        public async Task<RoleUser?> UpdateRoleUser([FromForm] string roleUserId, [FromForm] UpdateRoleUserDto updateRoleUserDto){
            return await _roleUserService.UpdateRoleUser(roleUserId, updateRoleUserDto);
        }

        [CustomAuthorize("Super Admin")]
        [HttpPost]
        [Route("delete-roleUser")]
        public async Task<bool> DeleteRoleUser([FromForm] string roleUserId){
            return await _roleUserService.DeleteRoleUser(roleUserId);
        }

        //[CustomAuthorize("Admin")]
        [HttpPost, Route("request-roleUser")]
        public async Task<bool> RequestRoleUser([FromForm] string userId){
            return await _roleUserService.RequestForRoleUserAsync(userId, "Student");
        }

        [HttpPost, Route("update-request-roleUser")]
        public async Task<bool> UpdateRequestRoleUserAsync([FromForm] string userId, [FromForm] int status){
            return await _roleUserService.UpdateRequestForRoleUserAsync(userId, status);
        }
    }
}