using BE.Dto.EnrollCourse;
using BE.Models;

namespace BE.Services.Interfaces
{
    public interface IEnrollCourseService
    {
        

        //---------------------CRUD--------------------------//
        Task<List<EnrollCourse>> ViewAllEnrollCourses();
        Task<EnrollCourse?> CreateEnrollCourse(CreateEnrollCourseDto createEnrollCourseDto);
        Task<EnrollCourse?> UpdateEnrollCourse(string enrollCourseId, UpdateEnrollCourseDto updateEnrollCourseDto);
        Task<bool> DeleteEnrollCourse(string enrollCourseId);
    }
}
