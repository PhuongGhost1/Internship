using BE.Dto.Course.Lecture;
using BE.Dto.Lecture;
using BE.Models;
using static BE.Utils.Utils;

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

        public static Lecture ToCreateLectureDto(this CreateLectureDto createLectureDto, string chapId){
            return new Lecture{
                Id = GenerateIdModel("lecture"),
                CreatAt = GetTimeNow(),
                ChapterId = chapId,
                Index = createLectureDto.Index,
                Name = createLectureDto.Name,
                TimeVideo = createLectureDto.TimeVideo,
                VideoUrl = createLectureDto.VideoUrl
            };
        }

        public static Lecture ToUpdateLectureDto(this UpdateLectureDto updateLectureDto){
            return new Lecture{
                CreatAt = GetTimeNow(),
                ChapterId = updateLectureDto.ChapterId,
                Index = updateLectureDto.Index,
                Name = updateLectureDto.Name,
                TimeVideo = updateLectureDto.TimeVideo,
                VideoUrl = updateLectureDto.VideoUrl
            };
        }
    }
}