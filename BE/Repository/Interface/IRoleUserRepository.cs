using BE.Models;

namespace BE.Repository.Interface
{
    public interface IRoleUserRepository
    {
        Task<IEnumerable<string?>> GetUserRole(string userId);
        Task<bool> RequestForRoleUser(string userId, string roleName);
        Task<bool> UpdateRequestForRoleUser(string userId, int status);

        //---------------------CRUD--------------------------//
        Task<RoleUser?> GetRoleUserById(string roleUserId);
        Task<List<RoleUser>> GetAllRoleUsers();
        Task<RoleUser?> CreateRoleUser(RoleUser roleUser);
        Task<RoleUser?> UpdateRoleUser(RoleUser roleUser);
        Task<bool> DeleteRoleUser(string roleUserId);
    }
}