using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BE.Dto.Chapter
{
    public class ChapterItemDto
    {
        public string? ItemId { get; set; } = string.Empty;
        public string? Name { get; set; } = string.Empty;
        public int? Index { get; set; }
        public string? Type { get; set; } = string.Empty;
        public string? ChapterId {get; set;} = string.Empty;
    }
}