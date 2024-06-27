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
    }
}