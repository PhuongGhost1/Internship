using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BE.Dto.Course.Chapter
{
    public class ChapterDto
    {
        public int? NumberOfLecture {get; set;}
        public int? NumberOfQuiz {get; set;}
        public int? EstimatedLearningTime {get; set;}
        public List<string?>? SomeOfCategoriesInvolved {get; set;}
        public string? Name {get; set;} = string.Empty; 
    }
}