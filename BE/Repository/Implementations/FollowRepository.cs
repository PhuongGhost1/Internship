using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<IEnumerable<Follow>> GetAllFollowsAsync()
        {
            return await _context.Follows.ToListAsync();
        }

        public async Task<Follow> GetFollowByIdAsync(string id)
        {
            return await _context.Follows.FindAsync(id);
        }

        public async Task AddFollowAsync(Follow follow)
        {
            await _context.Follows.AddAsync(follow);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateFollowAsync(Follow follow)
        {
            _context.Follows.Update(follow);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteFollowAsync(string id)
        {
            var follow = await _context.Follows.FindAsync(id);
            if (follow != null)
            {
                _context.Follows.Remove(follow);
                await _context.SaveChangesAsync();
            }
        }
    }
}
