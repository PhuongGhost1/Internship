using System.Collections.Generic;
using System.Threading.Tasks;
using BE.Models;

namespace BE.Repository.Interface
{
    public interface IEnrollCourseRepository
    {
        Task<IEnumerable<EnrollCourse>> GetAllEnrollCoursesAsync();
        Task<EnrollCourse> GetEnrollCourseByIdAsync(string id);
        Task AddEnrollCourseAsync(EnrollCourse enrollCourse);
        Task UpdateEnrollCourseAsync(EnrollCourse enrollCourse);
        Task DeleteEnrollCourseAsync(string id);
    }
}
