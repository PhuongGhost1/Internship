using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BE.Dto.Course.Lecture;
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
        public LectureService(ILectureRepository lectureRepo, ICourseRepository courseRepo)
        {
            _lectureRepo = lectureRepo;
            _courseRepo = courseRepo;
        }

        public async Task<LectureDto> GetAllDataFromLectureByCourseId(string courseId)
        {
            var course = await _courseRepo.RetriveCourseInformationById(courseId);

            if(course == null) throw new Exception("Cannot find course");

            var lecture = await _lectureRepo.GetAllDataFromLectureByCourseId(courseId);

            return lecture.ToRequestAllDataFromList();
        }
    }
}