using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BE.Dto.Chapter
{
    public class CreateChapterDto
    {
        public string? CourseId {get; set;}
        public int? Index { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}