using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BE.Dto.InProgressDto
{
    public class UserProgressDto
    {
        public string? ChapterId { get; set; }
        public string? ChapterName { get; set; }
        public int? LectureCount { get; set; }
        public int? QuizCount { get; set; }
        public int? CompletedLectures { get; set; }
        public int? CompletedQuizzes { get; set; }
        public double? TotalTime { get; set; }
        public double? CompletedTime { get; set; }
    }
}