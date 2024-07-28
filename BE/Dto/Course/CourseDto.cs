using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BE.Dto.Category;
using BE.Dto.Chapter;

namespace BE.Dto.Course
{
    public class CourseDto
    {
        public string? CourseId { get; set; }
        public string? Name { get; set; } = string.Empty;
        public List<ChaptersDto> Chapters { get; set; }
        public List<CategoryDto> Categories { get; set; }
        public float? RatingAvg { get; set; }
        public int? RatingNumber { get; set; }
        public int? EstimatedLearningTime { get; set; }
        public string? ImageBackground { get; set; } = string.Empty;
    }
}