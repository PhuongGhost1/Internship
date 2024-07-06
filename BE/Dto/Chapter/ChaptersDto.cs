using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BE.Dto.Chapter
{
    public class ChaptersDto
    {
        public string? Id { get; set; } = string.Empty;
        public string? Name { get; set; }
        public int? Index {get; set;}
        public List<ChapterItemDto> Items { get; set; }
        public string? ChapId {get; set;} = string.Empty;
        public string? CourseId {get; set;} = string.Empty;
    }
}