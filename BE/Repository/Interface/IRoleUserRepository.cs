using BE.Models;

namespace BE.Repository.Interface
{
    public interface IRoleUserRepository
    {
        Task<IEnumerable<string?>> GetUserRole(string userId);

        //---------------------CRUD--------------------------//
        Task<RoleUser?> GetRoleUserById(string roleUserId);
        Task<List<RoleUser>> GetAllRoleUsers();
        Task<RoleUser?> CreateRoleUser(RoleUser roleUser);
        Task<RoleUser?> UpdateRoleUser(RoleUser roleUser);
        Task<bool> DeleteRoleUser(string roleUserId);
    }
}