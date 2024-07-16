using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BE.Dto.Comment
{
    public class CommentDto
    {
        public string? CommentId {get; set;}
        public string? CourseId { get; set; }
        public string? UserId { get; set; }
        public int? Rating { get; set; }
    }
}