using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BE.Dto.Category;
using BE.Mappers;
using BE.Models;
using BE.Repository.Interface;
using BE.Services.Interfaces;

namespace BE.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _cateRepo;
        public CategoryService(ICategoryRepository cateRepo)
        {
            _cateRepo = cateRepo;
        }

        public async Task<List<Category>> GetAllCategories()
        {
            var categories = await _cateRepo.GetCategories();

            if(categories == null) throw new Exception("No categories in stock!");

            return categories.ToList();
        }


        //---------------------CRUD--------------------------//
        public async Task<Category?> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            var createCategory = createCategoryDto.ToCreateCategory();

            if(createCategory == null) throw new Exception("Unable to create category!");

            return await _cateRepo.CreateCategory(createCategory);
        }

        public async Task<bool> DeleteCategory(string cateId)
        {
            var category = await _cateRepo.GetCategoryById(cateId);

            if(category == null) throw new Exception("Unable to find category!");

            return await _cateRepo.DeleteCategory(cateId);
        }

        public async Task<Category?> UpdateCategory(string cateId, UpdateCategoryDto updateCategoryDto)
        {
            var category = await _cateRepo.GetCategoryById(cateId);

            if(category == null) throw new Exception("Unable to find category!");

            var updateCategory = updateCategoryDto.ToUpdateCategory();

            if(updateCategory == null) throw new Exception("Unable to update category!");

            return await _cateRepo.UpdateCategory(updateCategory);
        }   
    }
}