using BE.Dto.Course.Lecture;
using BE.Models;

namespace BE.Mappers
{
    public static class LectureMappers
    {
        public static LectureDto ToRequestAllDataFromList(this Lecture lecture){
            return new LectureDto{
                Id = lecture.Id,
                Index = lecture.Index,
                ChapterId = lecture.ChapterId,
                Name = lecture.Name,
                Time_Video = lecture.TimeVideo,
                Video_Url = lecture.VideoUrl,
                Created_At = lecture.CreatAt,
                Status = lecture.Status,
                Images = lecture.Images.Select(i => i.ToImageData()).ToList(),
                Processings = lecture.Processings.Select(p => p.ToProcessingData()).ToList()
            };
        }
    }
}