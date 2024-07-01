using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BE.Dto.Chapter
{
    public class UpdateChapterDto
    {
        public string? ChapId {get; set;}
        public int? Index { get; set; }
        public string? CourseId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}