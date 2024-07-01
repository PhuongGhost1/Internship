using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BE.Dto.Course.Lecture;
using BE.Dto.Lecture;
using BE.Mappers;
using BE.Models;
using BE.Repository.Interface;
using BE.Services.Interfaces;

namespace BE.Services.Implementations
{
    public class LectureService : ILectureService
    {
        private readonly ILectureRepository _lectureRepo;
        private readonly ICourseRepository _courseRepo;
        private readonly IChapterRepository _chapRepo;
        public LectureService(ILectureRepository lectureRepo, ICourseRepository courseRepo, IChapterRepository chapRepo)
        {
            _lectureRepo = lectureRepo;
            _courseRepo = courseRepo;
            _chapRepo = chapRepo;
        }

        public async Task<LectureDto> GetAllDataFromLectureByCourseId(string courseId)
        {
            var course = await _courseRepo.RetriveCourseInformationById(courseId);

            if(course == null) throw new Exception("Cannot find course");

            var lecture = await _lectureRepo.GetAllDataFromLectureByCourseId(courseId);

            return lecture.ToRequestAllDataFromList();
        }



        //---------------------CRUD--------------------------//
        public async Task<Lecture?> CreateLecture(string chapId, CreateLectureDto createLectureDto)
        {
            var chapter = await _chapRepo.FindChapterById(chapId);

            if(chapter == null) throw new Exception("Unable to find chapter!");

            var createLecture = createLectureDto.ToCreateLectureDto(chapId);

            if(createLecture == null) throw new Exception("Unable to create Lecture!");

            return await _lectureRepo.CreateLecture(createLecture);
        }

        public async Task<bool> DeleteLecture(string lectureId)
        {
            var lecture = await _lectureRepo.GetLectureById(lectureId);

            if(lecture == null) throw new Exception("Unable to find lecture");

            return await _lectureRepo.DeleteLecture(lectureId);
        }

        public async Task<Lecture?> UpdateLecture(string lectureId, UpdateLectureDto updateLectureDto)
        {
            var lecture = await _lectureRepo.GetLectureById(lectureId);

            if(lecture == null) throw new Exception("Unable to find lecture");

            var updateLecture = updateLectureDto.ToUpdateLectureDto();

            if(updateLecture == null) throw new Exception("Unable to update lecture!");

            return await _lectureRepo.UpdateLecture(updateLecture);
        }

        public async Task<List<Lecture>> ViewAllLectures()
        {
            return await _lectureRepo.GetAllLectures();
        }
    }
}