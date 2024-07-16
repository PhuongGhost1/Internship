using BE.Models;
using BE.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace BE.Repository.Implementations
{
    public class SubmissionRepository : ISubmissionRepository
    {
        private readonly DbContext _context;

        public SubmissionRepository(DbContext context)
        {
            _context = context;
        }

        public async Task<Submission> AddAsync(Submission submission)
        {
            await _context.Set<Submission>().AddAsync(submission);
            await _context.SaveChangesAsync();
            return submission;
        }

        public async Task<Submission> UpdateAsync(Submission submission)
        {
            _context.Set<Submission>().Update(submission);
            await _context.SaveChangesAsync();
            return submission;
        }

        public async Task DeleteAsync(string id)
        {
            var submission = await _context.Set<Submission>().FindAsync(id);
            if (submission != null)
            {
                _context.Set<Submission>().Remove(submission);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Submission?> GetByIdAsync(string id)
        {
            return await _context.Set<Submission>().FindAsync(id);
        }

        public async Task<List<Submission>> GetAllAsync()
        {
            return await _context.Set<Submission>().ToListAsync();
        }
    }
}
