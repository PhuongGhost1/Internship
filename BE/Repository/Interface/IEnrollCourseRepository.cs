using BE.Models;
using BE.Dto;
using BE.Dto.Course;

namespace BE.Repository.Interface
{
    public interface IEnrollCourseRepository
    {
        Task<List<CourseProcessingDto>> GetEnrollCourseByUserId(string userID);


        //---------------------CRUD--------------------------//
        Task<EnrollCourse?> GetEnrollCourseById(string enrollCourseUserId);
        Task<List<EnrollCourse>> GetAllEnrollCourses();
        Task<EnrollCourse?> CreateEnrollCourse(EnrollCourse enrollCourseUser);
        Task<EnrollCourse?> UpdateEnrollCourse(EnrollCourse enrollCourseUser);
        Task<bool> DeleteEnrollCourse(string enrollCourseUserId);
    }
}
