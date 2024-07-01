using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BE.Dto.Chapter;
using BE.Dto.Course.Chapter;
using BE.Mappers;
using BE.Models;
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
        private readonly IChapterRepository _chapRepo;
        public ChapterService(IQuizRepository quizRepo, ILectureRepository lectureRepo, ICourseRepository courseRepo,
                                ICategoryRepository cateRepo, IChapterRepository chapRepo)
        {
            _quizRepo = quizRepo;
            _lectureRepo = lectureRepo;
            _courseRepo = courseRepo;
            _cateRepo = cateRepo;
            _chapRepo = chapRepo;
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




        //---------------------CRUD--------------------------//
        public async Task<Chapter?> CreateChapter(CreateChapterDto createChapterDto)
        {
            var couse = await _courseRepo.RetriveCourseInformationById(createChapterDto.CourseId);

            if(couse == null) throw new Exception("Unable to find course!");

            var createChapter = createChapterDto.ToCreateChapterDto(createChapterDto.CourseId);

            if(createChapter == null) throw new Exception("Unable to create chapter");

            return await _chapRepo.CreateChapter(createChapter);
        }

        public async Task<bool> DeleteChapter(string chapId)
        {
            var chapter = await _chapRepo.FindChapterById(chapId);

            if(chapId == null) throw new Exception("Unable to find chapter");

            return await _chapRepo.DeleteChapter(chapId);
        }

        public async Task<Chapter?> UpdateChapter(UpdateChapterDto updateChapterDto)
        {
            var chapter = await _chapRepo.FindChapterById(updateChapterDto.ChapId);

            if(updateChapterDto.ChapId == null) throw new Exception("Unable to find chapter");

            var updateChapter = updateChapterDto.ToUpdateChapterDto();

            if(updateChapter == null) throw new Exception("Unable to update chapter");

            return await _chapRepo.UpdateChapter(updateChapter);
        }

        public async Task<List<Chapter>> ViewAllChapters()
        {
            return await _chapRepo.GetAllChapters();
        }

        public async Task<Chapter?> GetChapterById(string chapId)
        {
            return await _chapRepo.FindChapterById(chapId);
        }

        public async Task<Chapter?> GetChapterByName(string chapName)
        {
            if(chapName == null) throw new Exception("Unable to find chapter!");

            return await _chapRepo.FindChapterByName(chapName);
        }
    }
}