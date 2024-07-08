using BE.Models;
using BE.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace BE.Repository.Implementations
{
    public class EnrollCourseRepository : IEnrollCourseRepository
    {
        private readonly CourseOnlContext _context;
        public EnrollCourseRepository(CourseOnlContext context)
        {
            _context = context;
        }



        //---------------------CRUD--------------------------//
        public async Task<EnrollCourse?> CreateEnrollCourse(EnrollCourse enrollCourse)
        {
            await _context.EnrollCourses.AddAsync(enrollCourse);
            await _context.SaveChangesAsync();
            return enrollCourse;
        }

        public async Task<bool> DeleteEnrollCourse(string enrollCourseId)
        {
            var enrollCourse = await _context.EnrollCourses.FindAsync(enrollCourseId);

            if(enrollCourse == null) return false;

            _context.EnrollCourses.Update(enrollCourse);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<EnrollCourse>> GetAllEnrollCourses()
        {
            return await _context.EnrollCourses.ToListAsync();
        }

        public async Task<EnrollCourse?> GetEnrollCourseById(string enrollCourseId)
        {
            return await _context.EnrollCourses.FirstOrDefaultAsync(enrollCourse => enrollCourse.Id == enrollCourseId);
        }

        public async Task<EnrollCourse?> UpdateEnrollCourse(EnrollCourse enrollCourse)
        {
            _context.EnrollCourses.Update(enrollCourse);
            await _context.SaveChangesAsync();
            return enrollCourse;
        }
    }
}
