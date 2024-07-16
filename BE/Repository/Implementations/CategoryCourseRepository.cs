using BE.Models;
using BE.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace BE.Repository.Implementations
{
    public class CategoryCourseRepository : ICategoryCourseRepository
    {
        private readonly CourseOnlContext _context;
        public CategoryCourseRepository(CourseOnlContext context)
        {
            _context = context;
        }



        //---------------------CRUD--------------------------//
        public async Task<CategoryCourse?> CreateCategoryCourse(CategoryCourse categoryCourse)
        {
            await _context.CategoryCourses.AddAsync(categoryCourse);
            await _context.SaveChangesAsync();
            return categoryCourse;
        }

        public async Task<bool> DeleteCategoryCourse(string categoryCourseId)
        {
            var categoryCourse = await _context.CategoryCourses.FindAsync(categoryCourseId);

            if (categoryCourse == null) return false;

            _context.CategoryCourses.Remove(categoryCourse);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<CategoryCourse>> GetAllCategoryCourses()
        {
            return await _context.CategoryCourses.ToListAsync();
        }

        public async Task<CategoryCourse?> GetCategoryCourseById(string categoryCourseId)
        {
            return await _context.CategoryCourses.FirstOrDefaultAsync(categoryCourse => categoryCourse.Id == categoryCourseId);
        }

        public async Task<CategoryCourse?> UpdateCategoryCourse(CategoryCourse categoryCourse)
        {
            _context.CategoryCourses.Update(categoryCourse);
            await _context.SaveChangesAsync();
            return categoryCourse;
        }

        public async Task<List<Category>> GetAllCategoryOfCouse(string courseId)
        {
            var CategoryCourse = await _context.CategoryCourses
                                .Where(cc => cc.CourseId == courseId)
                                .Select(cc => cc.CategoryId)
                                .ToListAsync();
            var Categories = await _context.Categories
                            .Where(c => CategoryCourse.Contains(c.Id))
                            .ToListAsync();
            return Categories;
        }
    }
}
