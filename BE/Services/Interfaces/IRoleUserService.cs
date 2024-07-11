using BE.Dto.RoleUser;
using BE.Models;

namespace BE.Services.Interfaces
{
    public interface IRoleUserService
    {
        Task<bool> RequestForRoleUserAsync(string userId, string roleName);
        Task<bool> UpdateRequestForRoleUserAsync(string userId, int status);

        //---------------------CRUD--------------------------//
        Task<List<RoleUser>> ViewAllRoleUsers();
        Task<RoleUser?> CreateRoleUser(CreateRoleUserDto createRoleUserDto);
        Task<RoleUser?> UpdateRoleUser(string roleUserId, UpdateRoleUserDto updateRoleUserDto);
        Task<bool> DeleteRoleUser(string roleUserId);
    }
}