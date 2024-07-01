using System.Collections.Generic;
using System.Threading.Tasks;
using BE.Models;

namespace BE.Repository.Interface
{
    public interface IRoleRepository
    {
        Task<IEnumerable<Role>> GetAllRolesAsync();
        Task<Role> GetRoleByIdAsync(string id);
        Task AddRoleAsync(Role role);
        Task UpdateRoleAsync(Role role);
        Task DeleteRoleAsync(string id);
    }
}
