using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BE.Models;

namespace BE.Repository.Interface
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetCategories();
        Task<List<Category>> GetCategoriesByCourseId(string courseId);
        Task<Category?> FindCategoryByName(string cateName);


        //---------------------CRUD--------------------------//
        Task<Category?> GetCategoryById(string cateId);
        Task<Category?> CreateCategory(Category category);
        Task<Category?> UpdateCategory(Category category);
        Task<bool> DeleteCategory(string cateId);
    }
}