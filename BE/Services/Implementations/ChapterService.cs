using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BE.Dto.Course.Chapter;
using BE.Repository.Interface;
using BE.Services.Interfaces;

namespace BE.Services.Implementations
{
    public class ChapterService : IChapterService
    {
        private readonly IQuizRepository _quizRepo;
        private readonly ILectureRepository _lectureRepo;
        private readonly ICourseRepository _courseRepo;
        private readonly ICategoryRepository _cateRepo;
        public ChapterService(IQuizRepository quizRepo, ILectureRepository lectureRepo, ICourseRepository courseRepo,
                                ICategoryRepository cateRepo)
        {
            _quizRepo = quizRepo;
            _lectureRepo = lectureRepo;
            _courseRepo = courseRepo;
            _cateRepo = cateRepo;
        }

        public async Task<ChapterDto> GetDataFromChapterInCourse(string courseId)
        {
            var courseModel = await _courseRepo.RetriveCourseInformationById(courseId);

            if(courseModel == null) throw new Exception("Cannot find course");

            var categoriesInvolvedInCourse = await _cateRepo.GetCategoriesByCourseId(courseId);

            if(categoriesInvolvedInCourse == null) throw new Exception("Cannot find category");

            var NumberOfQuizInChapter = await _quizRepo.NumberOfQuizInChapterByCourseId(courseId);
            var NumberOfLectureInChapter = await _lectureRepo.NumberOfLectureInChapterByCourseId(courseId);
            var totalVideoTime = await _lectureRepo.CalculateTotalVideoTimeByCourseId(courseId);
            return new ChapterDto{
                Name = courseModel.Name,
                NumberOfLecture = (int)NumberOfLectureInChapter,
                NumberOfQuiz = (int)NumberOfQuizInChapter,
                EstimatedLearningTime = totalVideoTime + NumberOfQuizInChapter*30,
                SomeOfCategoriesInvolved = categoriesInvolvedInCourse.Select(cate => cate.Name).ToList()
            };
        }
    }
}