using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BE.Repository.Interface
{
    public interface IQuizRepository
    {
        Task<int?> NumberOfQuizInChapterByCourseId(string courseId);
    }
}