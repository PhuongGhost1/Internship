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

        [HttpGet]
        [Route("lecture-data")]
        public async Task<LectureDto> GetAllDataFromLectureByCourseId([FromBody] string courseId){
            return await _lectureService.GetAllDataFromLectureByCourseId(courseId);
        }


        //---------------------CRUD--------------------------//
        [HttpGet]
        [Route("view-all-lectures")]
        public async Task<List<Lecture>> ViewAllLectures(){
            return await _lectureService.ViewAllLectures();
        }

        [HttpPost]
        [Route("create-lecture")]
        public async Task<Lecture?> CreateLecture([FromBody] CreateLectureDto createLectureDto){
            return await _lectureService.CreateLecture(createLectureDto);
        }

        [HttpPost]
        [Route("update-lecture")]
        public async Task<Lecture?> UpdateLecture([FromBody] UpdateLectureDto updateLectureDto){
            return await _lectureService.UpdateLecture(updateLectureDto);
        }

        [HttpPost]
        [Route("delete-lecture")]
        public async Task<bool> DeleteLecture([FromBody] string lectureId){
            return await _lectureService.DeleteLecture(lectureId);
        }
    }
}