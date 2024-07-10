using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BE.Dto.Category;

namespace BE.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<CategoryDto> GetAllCategories();
    }
}