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

        public async Task<string?> GetSaveCourseId(string userId, string courseId)
        {
            return await _context.SaveCourses.Where(sc => sc.UserId == userId && sc.CourseId == courseId).Select(sc => sc.Id).FirstOrDefaultAsync();
        }

        public async Task<bool> CheckSaveCourseExist(string userId, string courseId)
        {
            var saveCourse = await _context.SaveCourses.Where(sc => sc.UserId == userId && sc.CourseId == courseId).FirstOrDefaultAsync();

            return saveCourse != null;
        }

        //---------------------CRUD--------------------------//
        public async Task<SaveCourse?> CreateSaveCourse(SaveCourse saveCourse)
        {
            await _context.SaveCourses.AddAsync(saveCourse);
            await _context.SaveChangesAsync();
            return saveCourse;
        }

        public async Task<bool> DeleteSaveCourse(string saveCourseId)
        {
            var saveCourse = await _context.SaveCourses.FindAsync(saveCourseId);

            if (saveCourse == null) return false;

            _context.SaveCourses.Remove(saveCourse);
            _context.SaveCourses.Remove(saveCourse);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<SaveCourse>> GetAllSaveCourses()
        {
            return await _context.SaveCourses.ToListAsync();
        }

        public async Task<SaveCourse?> GetSaveCourseById(string saveCourseId)
        {
            return await _context.SaveCourses.FirstOrDefaultAsync(saveCourse => saveCourse.Id == saveCourseId);
        }

        public async Task<SaveCourse?> UpdateSaveCourse(SaveCourse saveCourse)
        {
            _context.SaveCourses.Update(saveCourse);
            await _context.SaveChangesAsync();
            return saveCourse;
        }
        public async Task<List<Course>> GetListSaveCourse(string userId)
        {
            var SaveCourseIds = await _context.SaveCourses.Where(sv => sv.UserId == userId)
                                .Select(sv => sv.CourseId).ToListAsync();
            var savedCourses = await _context.Courses.Where(c => SaveCourseIds.Contains(c.Id) && c.Status == 0)
                                .ToListAsync();
            return savedCourses;
        }
    }
}
