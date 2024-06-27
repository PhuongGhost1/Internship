using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BE.Models;

namespace BE.Repository.Interface
{
        public interface IQuizRepository
        {
                Task<int?> NumberOfQuizInChapterByCourseId(string courseId);
                Task<Quiz?> GetAllDataFromQuizByCourseId(string courseId);
                Task<Quiz?> GetDataOfQuizByQuizId(string quizId);
        }
}