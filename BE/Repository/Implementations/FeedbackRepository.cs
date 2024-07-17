using BE.Models;
using BE.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace BE.Repository.Implementations
{
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly DbContext _context;

        public FeedbackRepository(DbContext context)
        {
            _context = context;
        }

        public async Task<Feedback> AddAsync(Feedback feedback)
        {
            await _context.Set<Feedback>().AddAsync(feedback);
            await _context.SaveChangesAsync();
            return feedback;
        }

        public async Task<Feedback> UpdateAsync(Feedback feedback)
        {
            _context.Set<Feedback>().Update(feedback);
            await _context.SaveChangesAsync();
            return feedback;
        }

        public async Task DeleteAsync(string id)
        {
            var feedback = await _context.Set<Feedback>().FindAsync(id);
            if (feedback != null)
            {
                _context.Set<Feedback>().Remove(feedback);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Feedback?> GetByIdAsync(string id)
        {
            return await _context.Set<Feedback>().FindAsync(id);
        }

        public async Task<List<Feedback>> GetAllAsync()
        {
            return await _context.Set<Feedback>().ToListAsync();
        }
    }
}
