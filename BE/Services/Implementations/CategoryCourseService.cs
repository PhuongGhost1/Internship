using BE.Dto.CategoryCourse;
using BE.Mappers;
using BE.Models;
using BE.Repository.Interface;
using BE.Services.Interfaces;

namespace BE.Services.Implementations
{
    public class CategoryCourseService : ICategoryCourseService
    {
        private readonly ICategoryCourseRepository _categoryCourseRepo;
        private readonly IUserRepository _userRepo;
        public CategoryCourseService(ICategoryCourseRepository categoryCourseRepo, IUserRepository userRepo)
        {
            _categoryCourseRepo = categoryCourseRepo;
            _userRepo = userRepo;
        }


        //---------------------CRUD--------------------------//
        public async Task<CategoryCourse?> CreateCategoryCourse( CreateCategoryCourseDto createCategoryCourseDto)
        {

            var createCategoryCourse = createCategoryCourseDto.ToCreateCategoryCourse();

            if(createCategoryCourse == null) throw new Exception("Unable to create role-user!");

            return await _categoryCourseRepo.CreateCategoryCourse(createCategoryCourse);
        }

        public async Task<bool> DeleteCategoryCourse(string categoryCourseId)
        {
            var categoryCourse = await _categoryCourseRepo.GetCategoryCourseById(categoryCourseId);

            if(categoryCourse == null) throw new Exception("Unable to find role-user!");

            return await _categoryCourseRepo.DeleteCategoryCourse(categoryCourseId);
        }

        public async Task<CategoryCourse?> UpdateCategoryCourse(string categoryCourseId, UpdateCategoryCourseDto updateCategoryCourseDto)
        {
            var categoryCourse = await _categoryCourseRepo.GetCategoryCourseById(categoryCourseId);

            if(categoryCourse == null) throw new Exception("Unable to find role-user!");

            var updateCategoryCourse = updateCategoryCourseDto.ToUpdateCategoryCourse();

            if(updateCategoryCourse == null) throw new Exception("Unable to update role-user!");

            return await _categoryCourseRepo.UpdateCategoryCourse(updateCategoryCourse);
        }

        public async Task<List<CategoryCourse>> ViewAllCategoryCourses()
        {
            return await _categoryCourseRepo.GetAllCategoryCourses();
        }
    }
}
