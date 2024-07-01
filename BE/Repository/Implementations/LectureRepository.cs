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

        public async Task<Lecture> GetAllDataFromLectureByCourseId(string courseId)
        {
            var data = await
                        (from lecture in _context.Lectures
                         join chap in _context.Chapters on lecture.ChapterId equals chap.Id
                         join course in _context.Courses on chap.CourseId equals course.Id
                         join image in _context.Images on lecture.Id equals image.LectureId
                         join processing in _context.Processings on lecture.Id equals processing.LectureId
                         where course.Id == courseId
                         select lecture)
                        .Include(l => l.Images)
                        .Include(l => l.Processings)
                        .FirstOrDefaultAsync();
            if (data == null) throw new Exception("Unable to get data!");
            return data;
        }


        //---------------------CRUD--------------------------//

        public async Task<Lecture?> GetLectureById(string lectureId)
        {
            return await _context.Lectures.FirstOrDefaultAsync(lec => lec.Id == lectureId);
        }

        public async Task<List<Lecture>> GetAllLectures()
        {
            return await _context.Lectures.ToListAsync();
        }

        public async Task<Lecture?> CreateLecture(Lecture lecture)
        {
            await _context.Lectures.AddAsync(lecture);
            await _context.SaveChangesAsync();
            return lecture;
        }

        public async Task<Lecture?> UpdateLecture(Lecture lecture)
        {
            _context.Lectures.Update(lecture);
            await _context.SaveChangesAsync();
            return lecture;
        }

        public async Task<bool> DeleteLecture(string lectureId)
        {
            var lecture = await _context.Lectures.FindAsync(lectureId);

            if (lecture == null) return false;

            lecture.Status = 0;

            _context.Lectures.Update(lecture);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}