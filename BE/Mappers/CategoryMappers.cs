using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BE.Dto.Category;
using BE.Models;
using static BE.Utils.Utils;

namespace BE.Mappers
{
    public static class CategoryMappers
    {
        public static CategoryDto ToCategoryList(this List<Category> categories){
            return new CategoryDto {
                Names = categories.Select(cate => cate.Name).ToList()
            };
        }

        public static Category ToCreateCategory(this CreateCategoryDto createCategoryDto){
            return new Category{
                Id = GenerateIdModel("category"),
                Name = createCategoryDto.Name
            };
        }

        public static Category ToUpdateCategory(this UpdateCategoryDto updateCategoryDto){
            return new Category{
                Name = updateCategoryDto.Name
            };
        }
    }
}