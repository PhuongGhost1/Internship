using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BE.Dto.Course.Lecture;
using BE.Dto.Lecture;
using BE.Models;

namespace BE.Services.Interfaces
{
    public interface ILectureService
    {
        Task<LectureDto> GetAllDataFromLectureByCourseId(string courseId);


        //---------------------CRUD--------------------------//
        Task<List<Lecture>> ViewAllLectures();
        Task<Lecture?> CreateLecture(string chapId, CreateLectureDto createLectureDto);
        Task<Lecture?> UpdateLecture(string lectureId, UpdateLectureDto updateLectureDto);
        Task<bool> DeleteLecture(string lectureId);
    }
}