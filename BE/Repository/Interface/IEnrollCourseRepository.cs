using System.Collections.Generic;
using System.Threading.Tasks;
using BE.Models;

namespace BE.Repository.Interface
{
    public interface ISaveCourseRepository
    {
        Task<IEnumerable<SaveCourse>> GetAllSaveCoursesAsync();
        Task<SaveCourse> GetSaveCourseByIdAsync(string id);
        Task AddSaveCourseAsync(SaveCourse saveCourse);
        Task UpdateSaveCourseAsync(SaveCourse saveCourse1aveCourse);
        Task DeleteSaveCourseAsync(string id);
    }
}
