using BE.Attributes;
using BE.Dto.Role;
using BE.Models;
using BE.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BE.Controllers
{
    [ApiController]
    [Route("api/v1/web/role-user")]
    public class RoleWebController 
    {
        private readonly IRoleService _roleService;
        public RoleWebController(IRoleService roleService)
        {
            _roleService = roleService;
        }


        //---------------------CRUD--------------------------//
        [CustomAuthorize("Super Admin")]
        [HttpGet]
        [Route("view-all-roles")]
        public async Task<List<Role>> ViewAllRoles(){
            return await _roleService.ViewAllRoles();
        }

        [CustomAuthorize("Super Admin")]
        [HttpPost]
        [Route("create-role")]
        public async Task<Role?> CreateRole([FromForm] CreateRoleDto createRoleDto){
            return await _roleService.CreateRole (createRoleDto);
        }

        [CustomAuthorize("Super Admin")]
        [HttpPost]
        [Route("update-role")]
        public async Task<Role?> UpdateRole([FromForm] string roleId, [FromForm] UpdateRoleDto updateRoleDto){
            return await _roleService.UpdateRole(roleId, updateRoleDto);
        }

        [CustomAuthorize("Super Admin")]
        [HttpPost]
        [Route("delete-role")]
        public async Task<bool> DeleteRole([FromForm] string roleId){
            return await _roleService.DeleteRole(roleId);
        }
    }
}
