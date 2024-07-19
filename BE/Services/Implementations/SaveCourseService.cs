using BE.Dto.Course;
using BE.Dto.SaveCourse;
using BE.Mappers;
using BE.Models;
using BE.Repository.Interface;
using BE.Services.Interfaces;

namespace BE.Services.Implementations
{
    public class SaveCourseService : ISaveCourseService
    {
        private readonly ISaveCourseRepository _saveCourseRepo;
        private readonly ICourseRepository _courseRepo;
        private readonly ICategoryCourseRepository _categoryCourseRepo;
        private readonly IUserRepository _userRepo;
        public SaveCourseService(ISaveCourseRepository saveCourseRepo, ICourseRepository courseRepo, ICategoryCourseRepository categoryCourseRepo, IUserRepository userRepo)
        {
            _saveCourseRepo = saveCourseRepo;
            _userRepo = userRepo;
            _courseRepo = courseRepo;
            _categoryCourseRepo = categoryCourseRepo;
        }


        //---------------------CRUD--------------------------//
        public async Task<SaveCourse?> CreateSaveCourse(CreateSaveCourseDto createSaveCourseDto)
        {

            var createSaveCourse = createSaveCourseDto.ToCreateSaveCourse();

            if (createSaveCourse == null) throw new Exception("Unable to create save-course!");

            return await _saveCourseRepo.CreateSaveCourse(createSaveCourse);
        }

        public async Task<bool> DeleteSaveCourse(string saveCourseId)
        {
            var saveCourse = await _saveCourseRepo.GetSaveCourseById(saveCourseId);

            if (saveCourse == null) throw new Exception("Unable to find save-course!");

            return await _saveCourseRepo.DeleteSaveCourse(saveCourseId);
        }

        public async Task<SaveCourse?> UpdateSaveCourse(string saveCourseId, UpdateSaveCourseDto updateSaveCourseDto)
        {
            var saveCourse = await _saveCourseRepo.GetSaveCourseById(saveCourseId);

            if (saveCourse == null) throw new Exception("Unable to find save-course!");

            var updateSaveCourse = updateSaveCourseDto.ToUpdateSaveCourse();

            if (updateSaveCourse == null) throw new Exception("Unable to update save-course!");

            return await _saveCourseRepo.UpdateSaveCourse(updateSaveCourse);
        }

        public async Task<List<SaveCourse>> ViewAllSaveCourses()
        {
            return await _saveCourseRepo.GetAllSaveCourses();
        }
        public async Task<List<SaveCourseCard>> GetListSaveCourse(string userId)
        {
            var courses = await _saveCourseRepo.GetListSaveCourse(userId);
            var returnList = new List<SaveCourseCard>();
            foreach (var course in courses)
            {
                var saveCourseId = await _saveCourseRepo.GetSaveCourseId(userId, course.Id);
                var ratingCount = await _courseRepo.RetriveRatingNumber(course.Id);
                var categories = await _categoryCourseRepo.GetAllCategoryOfCouse(course.Id);
                var countLecture = await _courseRepo.CountLectureCourse(course.Id);
                var imgUrl = await _courseRepo.GetImageCourse(course.Id, "Background");
                var IdSaveCourse = await _saveCourseRepo.GetSaveCourseId(userId, course.Id);
                returnList.Add(new SaveCourseCard
                {
                    SaveCourseId = saveCourseId,
                    Name = course.Name,
                    CountLecture = countLecture,
                    Level = course.Level,
                    RatingAvg = course.Rating,
                    RatingCount = ratingCount,
                    Categories = categories,
                    ImgUrl = imgUrl
                });
            }
            return returnList;
        }
    }
}
