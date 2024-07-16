using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BE.Dto.Course
{
    public class CreateCourseDto
    {
        public string? UserId { get; set; }
        public string? Name { get; set; }
    }
}