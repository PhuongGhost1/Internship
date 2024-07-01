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
        [Route("lecture-data/{courseId}")]
        public async Task<LectureDto> GetAllDataFromLectureByCourseId([FromRoute] string courseId)
        {
            return await _lectureService.GetAllDataFromLectureByCourseId(courseId);
        }


        //---------------------CRUD--------------------------//
        [HttpGet]
        [Route("view-all-lectures")]
        public async Task<List<Lecture>> ViewAllLectures(){
            return await _lectureService.ViewAllLectures();
        }

        [HttpPost]
        [Route("create-lecture/{chapId}")]
        public async Task<Lecture?> CreateLecture([FromRoute] string chapId, [FromBody] CreateLectureDto createLectureDto){
            return await _lectureService.CreateLecture(chapId, createLectureDto);
        }

        [HttpPost]
        [Route("update-lecture/{lectureId}")]
        public async Task<Lecture?> UpdateLecture([FromRoute] string lectureId, [FromBody] UpdateLectureDto updateLectureDto){
            return await _lectureService.UpdateLecture(lectureId, updateLectureDto);
        }

        [HttpPost]
        [Route("delete-lecture/{lectureId}")]
        public async Task<bool> DeleteLecture([FromRoute] string lectureId){
            return await _lectureService.DeleteLecture(lectureId);
        }
    }
}