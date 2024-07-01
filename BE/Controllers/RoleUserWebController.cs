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
        [HttpGet]
        [Route("view-all-roleUsers")]
        public async Task<List<RoleUser>> ViewAllRoleUsers(){
            return await _roleUserService.ViewAllRoleUsers();
        }

        [HttpPost]
        [Route("create-roleUser/{userId}")]
        public async Task<RoleUser?> CreateRoleUser([FromRoute] string userId, [FromBody] CreateRoleUserDto createRoleUserDto){
            return await _roleUserService.CreateRoleUser(userId, createRoleUserDto);
        }

        [HttpPost]
        [Route("update-roleUser/{roleUserId}")]
        public async Task<RoleUser?> UpdateRoleUser([FromRoute] string roleUserId, [FromBody] UpdateRoleUserDto updateRoleUserDto){
            return await _roleUserService.UpdateRoleUser(roleUserId, updateRoleUserDto);
        }

        [HttpPost]
        [Route("delete-roleUser/{roleUserId}")]
        public async Task<bool> DeleteRoleUser([FromRoute] string roleUserId){
            return await _roleUserService.DeleteRoleUser(roleUserId);
        }
    }
}