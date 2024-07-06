using BE.Models;

namespace BE.Repository.Interface
{
    public interface IEnrollCourseRepository
    {
        

        //---------------------CRUD--------------------------//
        Task<EnrollCourse?> GetEnrollCourseById(string enrollCourseUserId);
        Task<List<EnrollCourse>> GetAllEnrollCourses();
        Task<EnrollCourse?> CreateEnrollCourse(EnrollCourse enrollCourseUser);
        Task<EnrollCourse?> UpdateEnrollCourse(EnrollCourse enrollCourseUser);
        Task<bool> DeleteEnrollCourse(string enrollCourseUserId);
    }
}
