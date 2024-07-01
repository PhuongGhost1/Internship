using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BE.Models;
using BE.Repository.Interface;
using Microsoft.EntityFrameworkCore;


namespace BE.Repository.Implementations
{
    public class SaveCourseRepository : ISaveCourseRepository
    {
        private readonly CourseOnlContext _context;

        public SaveCourseRepository(CourseOnlContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SaveCourse>> GetAllSaveCoursesAsync()
        {
            return await _context.SaveCourses.ToListAsync();
        }

        public async Task<SaveCourse> GetSaveCourseByIdAsync(string id)
        {
            return await _context.SaveCourses.FindAsync();
        }

        public async Task AddSaveCourseAsync(SaveCourse saveCourse)
        {
            await _context.SaveCourses.AddAsync(saveCourse);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateSaveCourseAsync(SaveCourse saveCourse)
        {
            _context.SaveCourses.Update(saveCourse);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSaveCourseAsync(string id)
        {
            var SaveCourse = await _context.SaveCourses.FindAsync(id);
            if (SaveCourse != null)
            {
                _context.SaveCourses.Remove(SaveCourse);
                await _context.SaveChangesAsync();
            }
        }
    }
}
