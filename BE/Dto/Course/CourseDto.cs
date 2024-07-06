using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BE.Dto.Course
{
    public class CourseDto
    {
        public string? CourseId {get; set;}
        public string? Name {get; set;} = string.Empty;
        public float? RatingAvg {get; set;}
        public int? RatingNumber {get; set;}
        public int? EstimatedLearningTime {get; set;}
        public string? ImageBackground {get; set;} = string.Empty;
    }
}