using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BE.Dto.Course;
using BE.Models;
using BE.Repository.Interface;
using BE.Services.Interfaces;
using Google.Cloud.Storage.V1;
using Google.Apis.Auth.OAuth2;
using Microsoft.AspNetCore.Mvc;

namespace BE.Services.Implementations
{
    public class CourseService : ICourseService
    {
        private readonly StorageClient _storageClient;
        private readonly ICourseRepository _courseRepo;
        private readonly IImageRepository _imageRepo;
        private readonly IQuizRepository _quizRepo;
        private readonly ILectureRepository _lectureRepo;
        public CourseService(ICourseRepository courseRepo, IImageRepository imageRepo, IQuizRepository quizRepo,
                            ILectureRepository lectureRepo)
        {
            _courseRepo = courseRepo;
            _imageRepo = imageRepo;
            _quizRepo = quizRepo;
            _lectureRepo = lectureRepo;
            var googleCredential = GoogleCredential.FromFile("config/firebase.json");
            _storageClient = StorageClient.Create(googleCredential);
        }

        public async Task<List<Course>> GetAllCourses()
        {
            var courses = await _courseRepo.GetAllCourses();
            return courses;
        }

        public async Task<CourseDto> GetInformationOfCourse(string courseId)
        {
            var courseModel = await _courseRepo.RetriveCourseInformationById(courseId);

            if (courseModel == null) throw new Exception("Cannot find course!");

            var imageModel = await _imageRepo.GetImageByCourseId(courseId);

            if (imageModel == null) throw new Exception("Cannot find image!");

            var ratingAvg = await _courseRepo.RetriveRatingAverage(courseId);
            var ratingNum = await _courseRepo.RetriveRatingNumber(courseId);
            var NumberOfQuizInChapter = await _quizRepo.NumberOfQuizInChapterByCourseId(courseId);
            var totalVideoTimeMinutes = await _lectureRepo.CalculateTotalVideoTimeByCourseId(courseId);
            var courseDto = new CourseDto
            {
                Name = courseModel.Name,
                RatingAvg = ratingAvg,
                RatingNumber = ratingNum,
                EstimatedLearningTime = totalVideoTimeMinutes + NumberOfQuizInChapter * 30,
                ImageBackground = imageModel?.Base64Code,
            };
            return courseDto;
        }

        public async Task<string> UploadImgCourse(int courseId, IFormFile image)
        {
            if (image == null || image.Length == 0)
            {
                throw new ArgumentException("File is empty");
            }
            return "hi";
        }

        public async Task<string> CreateCourse(CreateCoursData data)
        {
            return await _courseRepo.CreateCourse(data);
        }
    }
}