using BE.Models;

namespace BE.Repository.Interface
{
    public interface IRoleRepository
    {
        

        //---------------------CRUD--------------------------//
        Task<Role?> GetRoleById(string roleUserId);
        Task<List<Role>> GetAllRoles();
        Task<Role?> CreateRole(Role roleUser);
        Task<Role?> UpdateRole(Role roleUser);
        Task<bool> DeleteRole(string roleUserId);
    }
}
