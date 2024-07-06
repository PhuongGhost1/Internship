using BE.Dto.EnrollCourse;
using BE.Mappers;
using BE.Models;
using BE.Repository.Interface;
using BE.Services.Interfaces;

namespace BE.Services.Implementations
{
    public class EnrollCourseService : IEnrollCourseService
    {
        private readonly IEnrollCourseRepository _enrollCourseRepo;
        private readonly IUserRepository _userRepo;
        public EnrollCourseService(IEnrollCourseRepository enrollCourseRepo, IUserRepository userRepo)
        {
            _enrollCourseRepo = enrollCourseRepo;
            _userRepo = userRepo;
        }


        //---------------------CRUD--------------------------//
        public async Task<EnrollCourse?> CreateEnrollCourse( CreateEnrollCourseDto createEnrollCourseDto)
        {

            var createEnrollCourse = createEnrollCourseDto.ToCreateEnrollCourse();

            if(createEnrollCourse == null) throw new Exception("Unable to create role-user!");

            return await _enrollCourseRepo.CreateEnrollCourse(createEnrollCourse);
        }

        public async Task<bool> DeleteEnrollCourse(string enrollCourseId)
        {
            var enrollCourse = await _enrollCourseRepo.GetEnrollCourseById(enrollCourseId);

            if(enrollCourse == null) throw new Exception("Unable to find role-user!");

            return await _enrollCourseRepo.DeleteEnrollCourse(enrollCourseId);
        }

        public async Task<EnrollCourse?> UpdateEnrollCourse(string enrollCourseId, UpdateEnrollCourseDto updateEnrollCourseDto)
        {
            var enrollCourse = await _enrollCourseRepo.GetEnrollCourseById(enrollCourseId);

            if(enrollCourse == null) throw new Exception("Unable to find role-user!");

            var updateEnrollCourse = updateEnrollCourseDto.ToUpdateEnrollCourse();

            if(updateEnrollCourse == null) throw new Exception("Unable to update role-user!");

            return await _enrollCourseRepo.UpdateEnrollCourse(updateEnrollCourse);
        }

        public async Task<List<EnrollCourse>> ViewAllEnrollCourses()
        {
            return await _enrollCourseRepo.GetAllEnrollCourses();
        }
    }
}
