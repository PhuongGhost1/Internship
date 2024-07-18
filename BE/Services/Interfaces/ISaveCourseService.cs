using BE.Dto.Course;
using BE.Dto.SaveCourse;
using BE.Models;

namespace BE.Services.Interfaces
{
    public interface ISaveCourseService
    {


        //---------------------CRUD--------------------------//
        Task<List<SaveCourse>> ViewAllSaveCourses();
        Task<SaveCourse?> CreateSaveCourse(CreateSaveCourseDto createSaveCourseDto);
        Task<SaveCourse?> UpdateSaveCourse(string saveCourseId, UpdateSaveCourseDto updateSaveCourseDto);
        Task<bool> DeleteSaveCourse(string saveCourseId);
        Task<List<SaveCourseCard>> GetListSaveCourse(string userId);
    }
}
