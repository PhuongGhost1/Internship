using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BE.Models;

namespace BE.Repository.Interface
{
    public interface ILectureRepository
    {
        Task<int?> CalculateTotalVideoTimeByCourseId(string courseId);
        Task<int?> NumberOfLectureInChapterByCourseId(string courseId);
        Task<Lecture> GetAllDataFromLectureByCourseId(string courseId);


        //---------------------CRUD--------------------------//
        Task<Lecture?> GetLectureById(string lectureId);
        Task<List<Lecture>> GetAllLectures();
        Task<Lecture?> CreateLecture(Lecture lecture);
        Task<Lecture?> UpdateLecture(Lecture lecture);
        Task<bool> DeleteLecture(string lectureId);
    }
}