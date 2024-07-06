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
        private readonly IUserRepository _userRepo;
        public SaveCourseService(ISaveCourseRepository saveCourseRepo, IUserRepository userRepo)
        {
            _saveCourseRepo = saveCourseRepo;
            _userRepo = userRepo;
        }


        //---------------------CRUD--------------------------//
        public async Task<SaveCourse?> CreateSaveCourse( CreateSaveCourseDto createSaveCourseDto)
        {

            var createSaveCourse = createSaveCourseDto.ToCreateSaveCourse();

            if(createSaveCourse == null) throw new Exception("Unable to create role-user!");

            return await _saveCourseRepo.CreateSaveCourse(createSaveCourse);
        }

        public async Task<bool> DeleteSaveCourse(string saveCourseId)
        {
            var saveCourse = await _saveCourseRepo.GetSaveCourseById(saveCourseId);

            if(saveCourse == null) throw new Exception("Unable to find role-user!");

            return await _saveCourseRepo.DeleteSaveCourse(saveCourseId);
        }

        public async Task<SaveCourse?> UpdateSaveCourse(string saveCourseId, UpdateSaveCourseDto updateSaveCourseDto)
        {
            var saveCourse = await _saveCourseRepo.GetSaveCourseById(saveCourseId);

            if(saveCourse == null) throw new Exception("Unable to find role-user!");

            var updateSaveCourse = updateSaveCourseDto.ToUpdateSaveCourse();

            if(updateSaveCourse == null) throw new Exception("Unable to update role-user!");

            return await _saveCourseRepo.UpdateSaveCourse(updateSaveCourse);
        }

        public async Task<List<SaveCourse>> ViewAllSaveCourses()
        {
            return await _saveCourseRepo.GetAllSaveCourses();
        }
    }
}
