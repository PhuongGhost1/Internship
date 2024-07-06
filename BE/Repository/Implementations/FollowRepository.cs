using BE.Models;
using BE.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace BE.Repository.Implementations
{
    public class FollowRepository : IFollowRepository
    {
        private readonly CourseOnlContext _context;
        public FollowRepository(CourseOnlContext context)
        {
            _context = context;
        }



        //---------------------CRUD--------------------------//
        public async Task<Follow?> CreateFollow(Follow follow)
        {
            await _context.Follows.AddAsync(follow);
            await _context.SaveChangesAsync();
            return follow;
        }

        public async Task<bool> DeleteFollow(string followId)
        {
            var follow = await _context.Follows.FindAsync(followId);

            if(follow == null) return false;

            _context.Follows.Remove(follow);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Follow>> GetAllFollows()
        {
            return await _context.Follows.ToListAsync();
        }

        public async Task<Follow?> GetFollowById(string followId)
        {
            return await _context.Follows.FirstOrDefaultAsync(follow => follow.Id == followId);
        }

        public async Task<Follow?> UpdateFollow(Follow follow)
        {
            _context.Follows.Update(follow);
            await _context.SaveChangesAsync();
            return follow;
        }
    }
}
