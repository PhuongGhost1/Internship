using System.Collections.Generic;
using System.Threading.Tasks;
using BE.Models;

namespace BE.Services.Interfaces
{
    public interface ISaveCourseService
    {
        Task<IEnumerable<SaveCourse>> GetAllSaveCoursesAsync();
        Task<SaveCourse> GetSaveCourseByIdAsync(string id);
        Task AddSaveCourseAsync(SaveCourse saveCourse);
        Task UpdateSaveCourseAsync(SaveCourse saveCourse);
        Task DeleteSaveCourseAsync(string id);
    }
}
