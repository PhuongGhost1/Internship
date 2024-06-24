using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BE.Dto.Course;
using BE.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace BE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseController : ControllerBase
    {
        private readonly ICourseRepository _courseRepo;
        private readonly IImageRepository _imageRepo;
        private readonly IChapterRepository _chapterRepo;
        private readonly IQuizRepository _quizRepo;
        private readonly ILectureRepository _lectureRepo;
        private readonly IUserRepository _userRepo;
        public CourseController(ICourseRepository courseRepo, IImageRepository imageRepo, IChapterRepository chapterRepo,
                                IQuizRepository quizRepo, ILectureRepository lectureRepo, IUserRepository userRepo)
        {
            _courseRepo = courseRepo;
            _imageRepo = imageRepo;
            _chapterRepo = chapterRepo;
            _quizRepo = quizRepo;
            _lectureRepo = lectureRepo;
            _userRepo = userRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCourses(){
            if(!ModelState.IsValid) return BadRequest(ModelState);

            var courses = await _courseRepo.GetAllCourses();
            
            if(courses == null) return BadRequest("Chua co course trong he thong!");

            return Ok(courses);
        }

        [HttpGet("course-info")]
        public async Task<IActionResult> GetInformationOfCourse(string courseId, string userId){
            if(!ModelState.IsValid) return BadRequest(ModelState);

            if(await _userRepo.CheckUserExistById(userId)) return BadRequest("User not found!");

            var courseModel = await _courseRepo.RetriveCourseInformationById(courseId, userId);

            if(courseModel == null) return BadRequest("Cannot found course");

            var imageModel = await _imageRepo.GetImageByCourseId(courseId);

            if(imageModel == null) return BadRequest("Cannot found image");

            var ratingAvg = await _courseRepo.RetriveRatingAverage(courseId, userId);
            var ratingNum = await _courseRepo.RetriveRatingNumber(courseId, userId);
            var numberChapters = await _chapterRepo.CountNumberChaptersByCourseId(courseId);
            var NumberOfQuizInChapter = await _quizRepo.NumberOfQuizInChapterByCourseId(courseId);
            var totalVideoTimeMinutes = await _lectureRepo.CalculateTotalVideoTimeByCourseId(courseId);

            return Ok(new CourseDto{
                Name = courseModel.Name,
                RatingAvg = ratingAvg,
                RatingNumber = ratingNum,
                EstimatedLearningTime = totalVideoTimeMinutes + NumberOfQuizInChapter*30,
                ImageBackground = imageModel.Base64Code,
            });
        }
    }
}