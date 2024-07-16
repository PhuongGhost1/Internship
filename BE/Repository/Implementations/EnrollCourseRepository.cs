using BE.Models;
using BE.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using BE.Dto;
using BE.Dto.Course;

namespace BE.Repository.Implementations
{
    public class EnrollCourseRepository : IEnrollCourseRepository
    {
        private readonly CourseOnlContext _context;
        public EnrollCourseRepository(CourseOnlContext context)
        {
            _context = context;
        }

        public async Task<List<CourseProcessingDto>> GetEnrollCourseByUserId(string userId)
        {
            var listCourseIds = await _context.EnrollCourses
                                  .Where(ec => ec.UserId == userId)
                                  .Select(ec => ec.CourseId)
                                  .ToListAsync();

            var listEnrollCourse = await _context.Courses
                                     .Where(c => listCourseIds.Contains(c.Id))
                                     .ToListAsync();


            var resultList = new List<CourseProcessingDto>();

            foreach (var ec in listEnrollCourse)
            {
                var imageBackground = await _context.Images.FirstOrDefaultAsync(img => img.CourseId == ec.Id);

                var chapterIds = await _context.Chapters
                                      .Where(ch => ch.CourseId == ec.Id)
                                      .Select(c => c.Id)
                                      .ToListAsync();


                var lectureIds = await _context.Lectures
                             .Where(l => chapterIds.Contains(l.ChapterId))
                             .Select(l => l.Id)
                             .ToListAsync();


                var quizzeIds = await _context.Quizzes
                                    .Where(q => chapterIds.Contains(q.ChapterId))
                                    .Select(l => l.Id)
                                    .ToListAsync();

                var combinedIds = lectureIds.Concat(quizzeIds).ToList();

                int countQuizzLecture = lectureIds.Count + quizzeIds.Count;

                int countProcessing = await _context.Processings
                                            .Where(p => p.UserId == userId &&
                                                        (combinedIds.Contains(p.QuizId) || combinedIds.Contains(p.LectureId)))
                                            .CountAsync();
                int result = countProcessing * 100 / countQuizzLecture;




                var courseProcessingDto = new CourseProcessingDto
                {
                    Id = ec.Id,
                    Name = ec.Name,
                    Description = ec.Description,
                    CreateAt = ec.CreateAt,
                    UpdateAt = ec.UpdateAt,
                    Price = ec.Price,
                    UserId = ec.UserId,
                    Status = ec.Status,
                    IsVisible = ec.IsVisible,
                    Rating = ec.Rating,
                    WhatLearn = ec.WhatLearn,
                    Percent = result,
                    ImageBackground = imageBackground.Url
                };

                resultList.Add(courseProcessingDto);
            }

            return resultList;
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

            if (enrollCourse == null) return false;

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
            var existingEnrollCourse = await _context.EnrollCourses.FindAsync(enrollCourse.Id);
            if (existingEnrollCourse != null)
            {
                _context.Entry(existingEnrollCourse).State = EntityState.Detached;
            }

            _context.EnrollCourses.Update(enrollCourse);
            await _context.SaveChangesAsync();
            return enrollCourse;
        }
    }
}
