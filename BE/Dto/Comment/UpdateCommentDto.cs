using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BE.Dto.Comment
{
    public class UpdateCommentDto
    {
        public int? Rating { get; set; }
        public string? Comment { get; set; }
    }
}