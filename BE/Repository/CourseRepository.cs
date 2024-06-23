using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BE.Models;
using BE.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace BE.Repository
{
    public class CourseRepository : ICourseRepository
    {
        private readonly CourseOnlContext _context;
        public CourseRepository(CourseOnlContext context)
        {
            _context = context;
        }
        public async Task<List<Course>> GetAllCourses()
        {
            return await _context.Courses.ToListAsync();
        }

        public async Task<Course?> RetriveCourseInformationById(string courseId, string userId)
        {
            var course = await 
                        (from c in _context.Courses
                        join ec in _context.EnrollCourses on c.Id equals ec.CourseId
                        join u in _context.Users on ec.UserId equals u.Id
                        where c.Id == courseId && u.Id == userId
                        select c)
                        .FirstOrDefaultAsync();

            return course;
        }

        public async Task<float?> RetriveRatingAverage(string courseId, string userId)
        {
            var ratingAvg = await 
                                (from c in _context.Courses
                                join ec in _context.EnrollCourses on c.Id equals ec.CourseId
                                join u in _context.Users on ec.UserId equals u.Id
                                join comment in _context.Comments on c.Id equals comment.CourseId
                                where c.Id == courseId && u.Id == userId && comment.UserId == u.Id
                                select comment.Rating)
                                .AverageAsync();

            return (float)ratingAvg;
        }

        public async Task<int?> RetriveRatingNumber(string courseId, string userId)
        {
            var ratingNum = await 
                            (from c in _context.Courses
                            join ec in _context.EnrollCourses on c.Id equals ec.CourseId
                            join u in _context.Users on ec.UserId equals u.Id
                            join comment in _context.Comments on c.Id equals comment.CourseId
                            where c.Id == courseId && u.Id == userId && comment.UserId == u.Id
                            select comment)
                            .CountAsync();

            return ratingNum;
        }
    }
}