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
        [Route("create-roleUser")]
        public async Task<RoleUser?> CreateRoleUser([FromForm] string userId, [FromForm] CreateRoleUserDto createRoleUserDto){
            return await _roleUserService.CreateRoleUser(userId, createRoleUserDto);
        }

        [HttpPost]
        [Route("update-roleUser")]
        public async Task<RoleUser?> UpdateRoleUser([FromForm] string roleUserId, [FromForm] UpdateRoleUserDto updateRoleUserDto){
            return await _roleUserService.UpdateRoleUser(roleUserId, updateRoleUserDto);
        }

        [HttpPost]
        [Route("delete-roleUser")]
        public async Task<bool> DeleteRoleUser([FromForm] string roleUserId){
            return await _roleUserService.DeleteRoleUser(roleUserId);
        }
    }
}