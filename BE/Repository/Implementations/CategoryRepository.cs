using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BE.Models;
using BE.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace BE.Repository.Implementations
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly CourseOnlContext _context;
        public CategoryRepository(CourseOnlContext context)
        {
            _context = context;
        }

        public async Task<Category?> FindCategoryByName(string cateName)
        {
            return await _context.Categories.FirstOrDefaultAsync(cate => cate.Name == cateName);
        }

        public async Task<List<Category>> GetCategories()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<List<Category>> GetCategoriesByCourseId(string courseId)
        {
            var categoriesInvolvedCourse = await
                                            (from cate in _context.Categories
                                             join cateCourse in _context.CategoryCourses on cate.Id equals cateCourse.CategoryId
                                             join course in _context.Courses on cateCourse.CourseId equals course.Id
                                             where course.Id == courseId
                                             select cate)
                                            .ToListAsync();
            return categoriesInvolvedCourse;
        }



        //---------------------CRUD--------------------------//
        public async Task<Category?> CreateCategory(Category category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<bool> DeleteCategory(string cateId)
        {
            var category = await _context.Categories.FindAsync(cateId);

            if (category == null) return false;

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Category?> UpdateCategory(Category category)
        {
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<Category?> GetCategoryById(string cateId)
        {
            return await _context.Categories.FirstOrDefaultAsync(cate => cate.Id == cateId);
        }

        public async Task<bool> UpdateStatusOfCategory(string cateId)
        {
            var cate = await _context.Categories.FindAsync(cateId);

            if (cate == null) return false;

            cate.IsVisible = !cate.IsVisible;

            _context.Categories.Update(cate);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}