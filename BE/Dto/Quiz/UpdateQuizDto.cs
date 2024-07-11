using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BE.Dto.Quiz
{
    public class UpdateQuizDto
    {
        public int? Index { get; set; }
        public string? ChapterId { get; set; }
        public string? Name { get; set; }
        public int? PassPercent { get; set; }
        public int? NumberQuestions { get; set; }
        public int? TotalMark { get; set; }
    }
}