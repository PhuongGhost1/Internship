using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BE.Models;
using BE.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace BE.Repository.Implementations
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

        public async Task<List<object>> GetLecturesAndQuizzesByCourseId(string courseId)
        {
            var lectures = await 
                    (from lecture in _context.Lectures
                     join chap in _context.Chapters on lecture.ChapterId equals chap.Id
                     join course in _context.Courses on chap.CourseId equals course.Id
                     where course.Id == courseId
                     select new { lecture.Index, Item = (object)lecture })
                    .ToListAsync();

            var quizzes = await
                        (from quiz in _context.Quizzes
                        join chap in _context.Chapters on quiz.ChapterId equals chap.Id
                        join course in _context.Courses on chap.CourseId equals course.Id
                        where course.Id == courseId
                        select new { quiz.Index, Item = (object)quiz })
                        .ToListAsync();

            var combinedList = lectures.Concat(quizzes)
                                    .OrderBy(x => x.Index)
                                    .Select(x => x.Item)
                                    .ToList();

            return combinedList;
        }

        public async Task<Course?> RetriveCourseInformationById(string courseId)
        {
            return await _context.Courses.FirstOrDefaultAsync(c => c.Id == courseId);
        }

        public async Task<float?> RetriveRatingAverage(string courseId)
        {
            var ratingAvg = await 
                                (from c in _context.Courses
                                join ec in _context.EnrollCourses on c.Id equals ec.CourseId
                                join comment in _context.Comments on c.Id equals comment.CourseId
                                where c.Id == courseId
                                select comment.Rating)
                                .AverageAsync();

            return (float)ratingAvg;
        }

        public async Task<int?> RetriveRatingNumber(string courseId)
        {
            var ratingNum = await 
                            (from c in _context.Courses
                            join ec in _context.EnrollCourses on c.Id equals ec.CourseId
                            join comment in _context.Comments on c.Id equals comment.CourseId
                            where c.Id == courseId
                            select comment)
                            .CountAsync();

            return ratingNum;
        }
    }
}