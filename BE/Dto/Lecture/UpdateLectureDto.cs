using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BE.Dto.Lecture
{
    public class UpdateLectureDto
    {
        public int? Index { get; set; }
        public string? ChapterId { get; set; }
        public string? Name { get; set; }
        public TimeSpan? TimeVideo { get; set; }
        public string? VideoUrl { get; set; }
    }
}