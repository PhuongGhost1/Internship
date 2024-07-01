using System.Collections.Generic;
using System.Threading.Tasks;
using BE.Models;
using BE.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace BE.Repository.Implementations
{
    public class PermissonRepository : IPermissonRepository
    {
        private readonly CourseOnlContext _context;

        public PermissonRepository(CourseOnlContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Permisson>> GetAllPermissonsAsync()
        {
            return await _context.Permissons.ToListAsync();
        }

        public async Task<Permisson> GetPermissonByIdAsync(string id)
        {
            return await _context.Permissons.FindAsync(id);
        }

        public async Task AddPermissonAsync(Permisson permisson)
        {
            _context.Permissons.Add(permisson);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePermissonAsync(Permisson permisson)
        {
            _context.Permissons.Update(permisson);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePermissonAsync(string id)
        {
            var permisson = await _context.Permissons.FindAsync(id);
            if (permisson != null)
            {
                _context.Permissons.Remove(permisson);
                await _context.SaveChangesAsync();
            }
        }
    }
}
