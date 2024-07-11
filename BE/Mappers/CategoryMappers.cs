using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BE.Dto.Category;
using BE.Models;

namespace BE.Mappers
{
    public static class CategoryMappers
    {
        public static CategoryDto ToCategoryList(this List<Category> categories){
            return new CategoryDto {
                Names = categories.Select(cate => cate.Name).ToList()
            };
        }
    }
}