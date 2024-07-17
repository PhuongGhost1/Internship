using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BE.Dto.ImageD;

namespace BE.Dto.Course
{
    public class NewReleaseCourseForHomepageDto
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public float? Price { get; set; }
        public float? RatingAvg { get; set; }
        public int? RatingCount { get; set; }
        public int? TimeLearning { get; set; }
        public string? Level { get; set; }
        public List<ImageForAdminDto> Image { get; set; } = new List<ImageForAdminDto>();
    }
}