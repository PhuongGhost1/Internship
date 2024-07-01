using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BE.Models;
using BE.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace BE.Repository.Implementations
{
    public class LectureRepository : ILectureRepository
    {
        private readonly CourseOnlContext _context;
        public LectureRepository(CourseOnlContext context)
        {
            _context = context;
        }

        public async Task<int?> NumberOfLectureInChapterByCourseId(string courseId)
        {
            var totalLectureInChapter = await
                                        (from lec in _context.Lectures
                                         join chap in _context.Chapters on lec.ChapterId equals chap.Id
                                         join course in _context.Courses on chap.CourseId equals course.Id
                                         where course.Id == courseId
                                         select lec)
                                        .CountAsync();

            return totalLectureInChapter;
        }

        public async Task<int?> CalculateTotalVideoTimeByCourseId(string courseId)
        {
            var totalVideoTimeMinutes = await
                                        (from chap in _context.Chapters
                                         join c in _context.Courses on chap.CourseId equals c.Id
                                         join l in _context.Lectures on chap.Id equals l.ChapterId
                                         where c.Id == courseId
                                         select l.TimeVideo)
                                        .ToListAsync();

            int sumTotalMinutes = totalVideoTimeMinutes.Sum(timeOnly => ToMinutes(timeOnly));

            return sumTotalMinutes;
        }

        private int ToMinutes(TimeSpan? timeOnly)
        {
            if (timeOnly.HasValue)
            {
                return timeOnly.Value.Hours * 60 + timeOnly.Value.Minutes;
            }
            else
            {
                return 0;
            }
        }
    }
}