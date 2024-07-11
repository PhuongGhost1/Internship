using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BE.Dto.Course.Chapter;

namespace BE.Services.Interfaces
{
    public interface IChapterService
    {
        Task<ChapterDto> GetDataFromChapterInCourse(string courseId);
    }
}