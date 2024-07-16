using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BE.Dto.Category;
using BE.Models;

namespace BE.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAllCategories();
        Task<bool> UpdateStatusOfCategoryAsync(string cateId);

        //---------------------CRUD--------------------------//
        Task<Category?> CreateCategory(CreateCategoryDto createCategoryDto);
        Task<Category?> UpdateCategory(UpdateCategoryDto updateCategoryDto);
        Task<bool> DeleteCategory(string cateId);
    }
}