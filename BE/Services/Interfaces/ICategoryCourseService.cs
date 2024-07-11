using BE.Dto.CategoryCourse;
using BE.Models;

namespace BE.Services.Interfaces
{
    public interface ICategoryCourseService
    {
        

        //---------------------CRUD--------------------------//
        Task<List<CategoryCourse>> ViewAllCategoryCourses();
        Task<CategoryCourse?> CreateCategoryCourse( CreateCategoryCourseDto createCategoryCourseDto);
        Task<CategoryCourse?> UpdateCategoryCourse(string categoryCourseId, UpdateCategoryCourseDto updateCategoryCourseDto);
        Task<bool> DeleteCategoryCourse(string categoryCourseId);
    }
}
