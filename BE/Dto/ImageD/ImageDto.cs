using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BE.Dto.ImageD
{
    public class ImageDto
    {
        public string? Id { get; set; }
        public string? Url { get; set; }
        public string? User_Id { get; set; }
        public string? Course_Id { get; set; }
        public string? Lecture_Id { get; set; }
        public string? Feedback_Id { get; set; }
        public DateTime? Created_At { get; set; }
    }
}