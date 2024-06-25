using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BE.Dto.Processing
{
    public class ProcessingDto
    {
        public string? Id { get; set; }

        public string? UserId { get; set; }

        public string? LectureId { get; set; }

        public string? QuizId { get; set; }

        public DateTime? CreateAt { get; set; }
    }
}