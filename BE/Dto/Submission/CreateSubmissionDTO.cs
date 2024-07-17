using System;
using System.Collections.Generic;
namespace BE.Dto.Submission
{
    public class CreateSubmissionDTO
    {
        public string? QuizId { get; set; }
        public string? UserId { get; set; }
        public double? Grade { get; set; }
        public DateTime? Date { get; set; }
        public bool? IsPass { get; set; }
    }
}
