using BE.Attributes;
using BE.Dto.Course.Lecture;
using BE.Dto.Lecture;
using BE.Models;
using BE.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BE.Controllers
{
    [Route("api/v1/web/lecture")]
    [ApiController]
    public class LectureWebController
    {
        private readonly ILectureService _lectureService;
        public LectureWebController(ILectureService lectureService)
        {
            _lectureService = lectureService;
        }

        [CustomAuthorize("Student", "Instructor")]
        [HttpGet]
        [Route("lecture-data")]
        public async Task<LectureDto> GetAllDataFromLectureByCourseId([FromForm] string courseId){
            return await _lectureService.GetAllDataFromLectureByCourseId(courseId);
        }


        //---------------------CRUD--------------------------//
        [CustomAuthorize("Student", "Instructor")]
        [HttpGet]
        [Route("view-all-lectures")]
        public async Task<List<Lecture>> ViewAllLectures(){
            return await _lectureService.ViewAllLectures();
        }

        [CustomAuthorize("Instructor")]
        [HttpPost]
        [Route("create-lecture")]
        public async Task<Lecture?> CreateLecture([FromForm] CreateLectureDto createLectureDto){
            return await _lectureService.CreateLecture(createLectureDto);
        }

        [CustomAuthorize("Instructor")]
        [HttpPost]
        [Route("update-lecture")]
        public async Task<Lecture?> UpdateLecture([FromForm] UpdateLectureDto updateLectureDto){
            return await _lectureService.UpdateLecture(updateLectureDto);
        }

        [CustomAuthorize("Instructor")]
        [HttpPost]
        [Route("delete-lecture")]
        public async Task<bool> DeleteLecture([FromForm] string lectureId){
            return await _lectureService.DeleteLecture(lectureId);
        }
    }
}