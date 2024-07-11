using BE.Models;
using BE.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace BE.Repository.Implementations
{
    public class ResourceRepository : IResourcesRepository
    {
        private readonly CourseOnlContext _context;
        public ResourceRepository(CourseOnlContext context)
        {
            _context = context;
        }

        //---------------------CRUD--------------------------//
        public async Task<Resource?> CreateResource(Resource resource)
        {
            await _context.Resources.AddAsync(resource);
            await _context.SaveChangesAsync();
            return resource;
        }

        public async Task<bool> DeleteResource(string resId)
        {
            var resource = await _context.Resources.FindAsync(resId);

            if(resource == null) return false;

            _context.Resources.Remove(resource);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Resource>> GetAllResources()
        {
            return await _context.Resources.ToListAsync();
        }

        public async Task<Resource?> GetResourceById(string resId)
        {
            return await _context.Resources.FirstOrDefaultAsync(res => res.Id == resId);
        }

        public async Task<Resource?> UpdateResource(Resource resource)
        {
            _context.Resources.Update(resource);
            await _context.SaveChangesAsync();
            return resource;
        }
    }
}