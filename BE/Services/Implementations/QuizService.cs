using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BE.Dto.Course.Chapter.Quiz;
using BE.Mappers;
using BE.Repository.Interface;
using BE.Services.Interfaces;

namespace BE.Services.Implementations
{
    public class QuizService : IQuizService
    {
        private readonly IQuizRepository _quizRepo;
        private readonly ICourseRepository _courseRepo;
        public QuizService(IQuizRepository quizRepo, ICourseRepository courseRepo)
        {
            _quizRepo = quizRepo;
            _courseRepo = courseRepo;
        }

        public async Task<QuizDto> GetAllDataFromQuizByCourseId(string courseId)
        {
            var course = await _courseRepo.RetriveCourseInformationById(courseId);

            if(course == null) throw new Exception("Not found course!");

            var quiz = await _quizRepo.GetAllDataFromQuizByCourseId(courseId);

            if(quiz == null) throw new Exception("Not found course!");

            return quiz.ToAllQuizDto();
        }
    }
}