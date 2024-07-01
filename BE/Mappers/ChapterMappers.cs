using BE.Dto.Chapter;
using BE.Models;
using static BE.Utils.Utils;

namespace BE.Mappers
{
    public static class ChapterMappers
    {
        public static Chapter ToCreateChapterDto(this CreateChapterDto createChapterDto, string courseId){
            return new Chapter{
                Id = GenerateIdModel("chapter"),
                CreateAt = GetTimeNow(),
                CourseId = courseId,
                Index = createChapterDto.Index,
                Name = createChapterDto.Name,
                Description = createChapterDto.Description
            };
        }

        public static Chapter ToUpdateChapterDto(this UpdateChapterDto updateChapterDto){
            return new Chapter{
                CreateAt = GetTimeNow(),
                CourseId = updateChapterDto.CourseId,
                Index = updateChapterDto.Index,
                Name = updateChapterDto.Name,
                Description = updateChapterDto.Description
            };
        }
    }
}