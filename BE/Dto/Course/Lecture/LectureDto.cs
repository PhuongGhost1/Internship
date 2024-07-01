using BE.Dto.ImageD;
using BE.Dto.Processing;
using BE.Models;

namespace BE.Dto.Course.Lecture
{
    public class LectureDto
    {
        public string? Id {get; set;}
        public int? Index {get; set;} 
        public string? ChapterId {get; set;}
        public string? Name {get; set;}
        public TimeSpan? Time_Video {get; set;}
        public string? Video_Url {get; set;}
        public DateTime? Created_At {get; set;}
        public int? Status {get; set;}
        public List<ImageDto> Images { get; set; } = new List<ImageDto>();
        public List<ProcessingDto> Processings { get; set; } = new List<ProcessingDto>();
    }
}