using BE.Models;
using BE.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace BE.Repository.Implementations
{
    public class RoleUserRepository : IRoleUserRepository
    {
        private readonly CourseOnlContext _context;
        public RoleUserRepository(CourseOnlContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<string?>> GetUserRole(string userId)
        {
            return await _context.RoleUsers.Where(rU => rU.UserId == userId)
                                        .Select(rU => rU.Role.Name)
                                        .ToListAsync();
        }

        //---------------------CRUD--------------------------//
        public async Task<RoleUser?> CreateRoleUser(RoleUser roleUser)
        {
            await _context.RoleUsers.AddAsync(roleUser);
            await _context.SaveChangesAsync();
            return roleUser;
        }

        public async Task<bool> DeleteRoleUser(string roleUserId)
        {
            var roleUser = await _context.RoleUsers.FindAsync(roleUserId);

            if(roleUser == null) return false;

            roleUser.Status = 0;

            _context.RoleUsers.Update(roleUser);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<RoleUser>> GetAllRoleUsers()
        {
            return await _context.RoleUsers.ToListAsync();
        }

        public async Task<RoleUser?> GetRoleUserById(string roleUserId)
        {
            return await _context.RoleUsers.FirstOrDefaultAsync(roleUser => roleUser.Id == roleUserId);
        }

        public async Task<RoleUser?> UpdateRoleUser(RoleUser roleUser)
        {
            _context.RoleUsers.Update(roleUser);
            await _context.SaveChangesAsync();
            return roleUser;
        }
    }
}