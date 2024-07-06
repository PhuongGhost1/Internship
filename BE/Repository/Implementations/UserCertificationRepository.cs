using BE.Models;
using BE.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace BE.Repository.Implementations
{
    public class UserCertificationRepository : IUserCertificationRepository
    {
        private readonly CourseOnlContext _context;
        public UserCertificationRepository(CourseOnlContext context)
        {
            _context = context;
        }



        //---------------------CRUD--------------------------//
        public async Task<UserCertification?> CreateUserCertification(UserCertification userCertification)
        {
            await _context.UserCertifications.AddAsync(userCertification);
            await _context.SaveChangesAsync();
            return userCertification;
        }

        public async Task<bool> DeleteUserCertification(string userCertificationId)
        {
            var userCertification = await _context.UserCertifications.FindAsync(userCertificationId);

            if(userCertification == null) return false;

            _context.UserCertifications.Remove(userCertification);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<UserCertification>> GetAllUserCertifications()
        {
            return await _context.UserCertifications.ToListAsync();
        }

        public async Task<UserCertification?> GetUserCertificationById(string userCertificationId)
        {
            return await _context.UserCertifications.FirstOrDefaultAsync(userCertification => userCertification.Id == userCertificationId);
        }

        public async Task<UserCertification?> UpdateUserCertification(UserCertification userCertification)
        {
            _context.UserCertifications.Update(userCertification);
            await _context.SaveChangesAsync();
            return userCertification;
        }
    }
}
