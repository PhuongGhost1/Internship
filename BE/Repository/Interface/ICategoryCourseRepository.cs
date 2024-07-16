using BE.Models;

namespace BE.Repository.Interface
{
    public interface ICategoryCourseRepository
    {


        //---------------------CRUD--------------------------//
        Task<CategoryCourse?> GetCategoryCourseById(string categoryCourseUserId);
        Task<List<CategoryCourse>> GetAllCategoryCourses();
        Task<CategoryCourse?> CreateCategoryCourse(CategoryCourse categoryCourseUser);
        Task<CategoryCourse?> UpdateCategoryCourse(CategoryCourse categoryCourseUser);
        Task<bool> DeleteCategoryCourse(string categoryCourseUserId);
        Task<List<Category>> GetAllCategoryOfCouse(string courseId);
    }
}
