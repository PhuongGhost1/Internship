using BE.Models;
using BE.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace BE.Repository.Implementations
{
    public class RoleRepository : IRoleRepository
    {
        private readonly CourseOnlContext _context;
        public RoleRepository(CourseOnlContext context)
        {
            _context = context;
        }



        //---------------------CRUD--------------------------//
        public async Task<Role?> CreateRole(Role role)
        {
            await _context.Roles.AddAsync(role);
            await _context.SaveChangesAsync();
            return role;
        }

        public async Task<bool> DeleteRole(string roleId)
        {
            var role = await _context.Roles.FindAsync(roleId);

            if(role == null) return false;

            _context.Roles.Remove(role);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Role>> GetAllRoles()
        {
            return await _context.Roles.ToListAsync();
        }

        public async Task<Role?> GetRoleById(string roleId)
        {
            return await _context.Roles.FirstOrDefaultAsync(role => role.Id == roleId);
        }

        public async Task<Role?> UpdateRole(Role role)
        {
            _context.Roles.Update(role);
            await _context.SaveChangesAsync();
            return role;
        }
    }
}
