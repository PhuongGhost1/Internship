using BE.Dto.Role;
using BE.Models;

namespace BE.Services.Interfaces
{
    public interface IRoleService
    {
        

        //---------------------CRUD--------------------------//
        Task<List<Role>> ViewAllRoles();
        Task<Role?> CreateRole(CreateRoleDto createRoleDto);
        Task<Role?> UpdateRole(string roleId, UpdateRoleDto updateRoleDto);
        Task<bool> DeleteRole(string roleId);
    }
}
