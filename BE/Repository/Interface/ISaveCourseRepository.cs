using BE.Models;

namespace BE.Repository.Interface
{
    public interface ISaveCourseRepository
    {
        Task<string?> GetSaveCourseId(string userId, string courseId);

        //---------------------CRUD--------------------------//
        Task<SaveCourse?> GetSaveCourseById(string saveCourseUserId);
        Task<List<SaveCourse>> GetAllSaveCourses();
        Task<SaveCourse?> CreateSaveCourse(SaveCourse saveCourseUser);
        Task<SaveCourse?> UpdateSaveCourse(SaveCourse saveCourseUser);
        Task<bool> DeleteSaveCourse(string saveCourseUserId);
        Task<List<Course>> GetListSaveCourse(string userId);
    }
}
