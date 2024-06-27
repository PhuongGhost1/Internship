using BE.Dto.Course.Lecture;
using BE.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BE.Controllers
{
    [Route("api/v1/web/lecture")]
    [ApiExplorerSettings(GroupName = "Web")]
    public class LectureWebController
    {
        private readonly ILectureService _lectureService;
        public LectureWebController(ILectureService lectureService)
        {
            _lectureService = lectureService;
        }

        [HttpGet]
        [Route("lecture-data/{courseId}")]
        public async Task<LectureDto> GetAllDataFromLectureByCourseId([FromRoute] string courseId){
            return await _lectureService.GetAllDataFromLectureByCourseId(courseId);
        }
    }
}