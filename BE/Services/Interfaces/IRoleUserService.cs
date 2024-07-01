using BE.Dto.RoleUser;
using BE.Models;

namespace BE.Services.Interfaces
{
    public interface IRoleUserService
    {
        

        //---------------------CRUD--------------------------//
        Task<List<RoleUser>> ViewAllRoleUsers();
        Task<RoleUser?> CreateRoleUser(string userId, CreateRoleUserDto createRoleUserDto);
        Task<RoleUser?> UpdateRoleUser(string roleUserId, UpdateRoleUserDto updateRoleUserDto);
        Task<bool> DeleteRoleUser(string roleUserId);
    }
}