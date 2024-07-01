using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BE.Dto.Course.Chapter.Quiz;
using BE.Dto.Quiz;
using BE.Mappers;
using BE.Models;
using BE.Repository.Interface;
using BE.Services.Interfaces;

namespace BE.Services.Implementations
{
    public class QuizService : IQuizService
    {
        private readonly IQuizRepository _quizRepo;
        private readonly ICourseRepository _courseRepo;
        private readonly IChapterRepository _chapRepo;
        public QuizService(IQuizRepository quizRepo, ICourseRepository courseRepo, IChapterRepository chapRepo)
        {
            _quizRepo = quizRepo;
            _courseRepo = courseRepo;
            _chapRepo = chapRepo;
        }

        public async Task<QuizDto> GetAllDataFromQuizByCourseId(string courseId)
        {
            var course = await _courseRepo.RetriveCourseInformationById(courseId);

            if(course == null) throw new Exception("Not found course!");

            var quiz = await _quizRepo.GetAllDataFromQuizByCourseId(courseId);

            if(quiz == null) throw new Exception("Not found course!");

            return quiz.ToAllQuizDto();
        }


        //---------------------CRUD--------------------------//
        public async Task<Quiz?> CreateQuiz(CreateQuizDto createQuizDto, string chapterId)
        {
            var chapter = await _chapRepo.FindChapterById(chapterId);

            if(chapter == null) throw new Exception("Unable to find chapter");

            var createQuiz = createQuizDto.ToCreateQuizDto(chapterId);
            
            if(createQuiz == null) throw new Exception("Unable to create quiz");

            return await _quizRepo.CreateQuiz(createQuiz);
        }

        public async Task<List<Quiz>> ViewAllQuizzes()
        {
            return await _quizRepo.ViewAllQuizzes();
        }

        public async Task<Quiz?> UpdateQuiz(string quizId, UpdateQuizDto updateQuizDto)
        {
            var quiz = await _quizRepo.GetQuizById(quizId);

            if(quiz == null) throw new Exception("Unable to update quiz");

            var updateQuiz = updateQuizDto.ToUpdateQuizDto();

            if(updateQuiz == null) throw new Exception("Unable to create quiz");

            return await _quizRepo.UpdateQuiz(updateQuiz);
        }

        public async Task<bool> DeleteQuiz(string quizId)
        {
            var quiz = await _quizRepo.GetQuizById(quizId);

            if(quiz == null) throw new Exception("Unable to delete quiz");

            return await _quizRepo.DeleteQuiz(quizId);
        }
    }
}