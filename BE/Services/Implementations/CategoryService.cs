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
    }
}