using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BE.Dto.Category
{
    public class CreateCategoryDto
    {
        public string? Name { get; set; }
        public bool? IsVisible {get; set;}
    }
}