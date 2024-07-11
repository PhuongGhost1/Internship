using BE.Dto.RoleUser;
using BE.Dto.User;
using BE.Models;
using BE.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using static BE.Utils.Utils;

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

        public async Task<bool> RequestForRoleUser(string userId, string roleName)
        {
            var roleId = await _context.Roles.Where(r => r.Name == roleName).Select(r => r.Id).FirstOrDefaultAsync();

            if(roleId == null) return false;

            var request = new RoleUser{
                Id = GenerateIdModel("roleuser"),
                UserId = userId,
                RoleId = roleId,
                Status = 0
            };

            await _context.RoleUsers.AddAsync(request);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateRequestForRoleUser(string userId, int status)
        {
            var roleId = await _context.Roles.Where(r => r.Name == "Student").Select(r => r.Id).FirstOrDefaultAsync();

            var roleUser = await _context.RoleUsers
                                        .Where(ru => ru.UserId == userId && ru.RoleId == roleId)
                                        .FirstOrDefaultAsync();

            if(roleUser == null) return false;

            var feedback = await _context.Feedbacks.Where(f => f.UserId == userId).FirstOrDefaultAsync();

            if(feedback == null) return false;

            roleUser.Status = status;
            feedback.IsRead = true;
            roleUser.UpdateDate = DateTime.UtcNow;

            _context.RoleUsers.Update(roleUser);
            _context.Feedbacks.Update(feedback);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}