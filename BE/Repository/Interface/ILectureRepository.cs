using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BE.Repository.Interface
{
    public interface ILectureRepository
    {
        Task<int?> CalculateTotalVideoTimeByCourseId(string courseId);
        Task<int?> CalculateTotalLectureInChapterByCourseId(string courseId);
    }
}