using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BE.Dto.Chapter;
using BE.Dto.Course;
using BE.Dto.Course.Chapter;
using BE.Helpers;
using BE.Models;
using BE.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using static BE.Utils.Utils;

namespace BE.Repository.Implementations
{
    public class CourseRepository : ICourseRepository
    {
        private readonly CourseOnlContext _context;
        public CourseRepository(CourseOnlContext context)
        {
            _context = context;
        }
        public async Task<List<Course>> GetAllCoursesByQueryName(SearchQueryObject searchQueryObject)
        {
            var courses = _context.Courses.AsQueryable();

            if(!string.IsNullOrWhiteSpace(searchQueryObject.Name)){
                courses = _context.Courses.Where(c => c.Name.Contains(searchQueryObject.Name));
            }

            return await courses.ToListAsync();
        }

        public async Task<CourseDto?> GetLecturesAndQuizzesByCourseId(string courseId)
        {
            var course = await _context.Courses
                .Where(c => c.Id == courseId)
                .Include(c => c.Chapters)
                .FirstOrDefaultAsync();

            if (course == null) return null;

            var chapterIds = course.Chapters.Select(ch => ch.Id).ToList();

            var lectures = await _context.Lectures
                .Where(l => chapterIds.Contains(l.ChapterId))
                .Select(l => new ChapterItemDto
                {
                    ItemId = l.Id,
                    Name = l.Name,
                    Index = l.Index,
                    Type = "Lecture",
                    ChapterId = l.ChapterId
                })
                .ToListAsync();

            var quizzes = await _context.Quizzes
                .Where(q => chapterIds.Contains(q.ChapterId))
                .Select(q => new ChapterItemDto
                {
                    ItemId = q.Id,
                    Name = q.Name,
                    Index = q.Index,
                    Type = "Quiz",
                    ChapterId = q.ChapterId
                })
                .ToListAsync();

            var chapterDtos = course.Chapters.Select(ch => new ChaptersDto
            {
                Id = ch.Id,
                Name = ch.Name,
                Index = ch.Index,
                Items = lectures
                    .Where(l => l.ChapterId == ch.Id)
                    .Concat(quizzes.Where(q => q.ChapterId == ch.Id))
                    .OrderBy(item => item.Index)
                    .ToList()
            }).OrderBy(x => x.Index).ToList();

            var courseDto = new CourseDto
            {
                CourseId = course.Id,
                Name = course.Name,
                Chapters = chapterDtos
            };

            return courseDto;
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

        public async Task<string> CreateCourse(CreateCoursData data)
        {
            try
            {
                string courseId = GenerateIdModel("course");
                var course = new Course
                {
                    Id = courseId,
                    Name = data.Name,
                    CreateAt = GetTimeNow(),
                    Description = data.Description,
                    Price = data.Price,
                    User = await _context.Users.FirstOrDefaultAsync(e => e.Username == data.OwnerUsername),
                    Status = 1,
                    IsVisible = true,
                    Rating = 0,
                    WhatLearn = data.WhatLearn,
                };
                _context.Courses.Add(course);
                string[] categories = data.Categories.Split(new string[] { ", " }, StringSplitOptions.None);
                foreach (string category in categories)
                {
                    var categoryOBJ = await _context.Categories.FirstOrDefaultAsync(e => e.Name == category);
                    var coursecategory = new CategoryCourse
                    {
                        Id = GenerateIdModel("categorycourse"),
                        Category = categoryOBJ,
                        CourseId = courseId,
                        CreatedAt = GetTimeNow(),
                    };
                    _context.CategoryCourses.Add(coursecategory);
                }
                await _context.SaveChangesAsync();
                return "success";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi tạo khóa học: {ex.Message}");
                return "error";
            }
        }

        public async Task<List<Course>> FindCourseByCategoryName(string partialCategoryName)
        {
            var courses = await
                        (from course in _context.Courses
                        join courseCate in _context.CategoryCourses on course.Id equals courseCate.CourseId
                        join cate in _context.Categories on courseCate.CategoryId equals cate.Id
                        where cate.Name.Contains(partialCategoryName)
                        select course)
                        .ToListAsync();

            return courses;
        }

        public async Task<List<Course>> FilterAllCoursesByObject(FilterQueryObject filterQueryObject)
        {
            var courses = _context.Courses
                            .Include(course => course.CategoryCourses)
                            .ThenInclude(cateCourse => cateCourse.Category)
                            .ThenInclude(cate => cate.CategoryCourses)
                            .AsQueryable();

            if (!string.IsNullOrWhiteSpace(filterQueryObject.CategoryName))
            {
                var categoryNameFilter = filterQueryObject.CategoryName.ToLower();

                courses = courses
                            .Where(course => course.CategoryCourses
                            .Any(cateCourse => cateCourse.Category.Name.ToLower().Contains(categoryNameFilter)))
                            .OrderByDescending(course => course.Name);
            }

            if(filterQueryObject.FromPrices > 0 && filterQueryObject.ToPrices > 0 && filterQueryObject.ToPrices > filterQueryObject.FromPrices){
                courses = courses
                            .Where(course => filterQueryObject.FromPrices <= course.Price && course.Price <= filterQueryObject.ToPrices)
                            .OrderByDescending(course => course.Price);
            }

            if(filterQueryObject.Rating > 0){
                courses = courses
                            .Where(course => course.Rating == filterQueryObject.Rating)
                            .OrderByDescending(course => course.Name);
            }

            // if(filterQueryObject.DifficultLevel > 0 || filterQueryObject.DifficultLevel < 4){
            //     courses = _context.Courses
            //                 .Where(course => course.)
            // }
             
            var skipNumber = (filterQueryObject.PageNumber - 1) * filterQueryObject.PageSize;

            if (skipNumber < 0) skipNumber = 0;     

            var result = await courses.Skip(skipNumber).Take(filterQueryObject.PageSize).ToListAsync();
 
            Console.WriteLine($"Courses count: {result.Count}");
            foreach (var course in result)
            {
                Console.WriteLine($"Course Name: {course.Name}");
                foreach (var categoryCourse in course.CategoryCourses)
                {
                    Console.WriteLine($"Category Name: {categoryCourse.Category.Name}");
                }
            }      
            
            return result;
        }

        public async Task<Course?> SearchCourseByUserId(string userId)
        {
            return await _context.Courses.FirstOrDefaultAsync(course => course.UserId == userId);
        }

        public async Task<List<Course>> GetRecentRandomCourses(int numberOfCourses)
        {
            var thirtyDaysAgo = DateTime.UtcNow.AddDays(-30);

            var recentCourses = await _context.Courses
                                        .Include(course => course.CategoryCourses)
                                            .ThenInclude(cateCourse => cateCourse.Category)
                                                .ThenInclude(cate => cate.CategoryCourses)
                                        .Include(course => course.Chapters)
                                            .ThenInclude(chapter => chapter.Lectures)
                                                .ThenInclude(image => image.Images)
                                        .Include(course => course.Chapters)
                                            .ThenInclude(quiz => quiz.Quizzes)
                                                .ThenInclude(question => question.Questions)
                                        .Include(course => course.Comments)
                                        .Include(images => images.Images)
                                        .Where(course => course.CreateAt >= thirtyDaysAgo)
                                        .OrderBy(c => Guid.NewGuid())
                                        .Take(numberOfCourses)
                                        .ToListAsync();
            return recentCourses;
        }

        //---------------------CRUD--------------------------//
        public async Task<Course?> CreateCourse(Course course)
        {
            await _context.Courses.AddAsync(course);
            await _context.SaveChangesAsync();
            return course;
        }

        public async Task<Course?> UpdateCourse(Course course)
        {
            _context.Courses.Update(course);
            await _context.SaveChangesAsync();
            return course;
        }

        public async Task<bool> DeleteCourse(string courseId)
        {
            var course = await _context.Courses.FindAsync(courseId);

            if(course == null) return false;

            course.Status = 0;

            _context.Courses.Update(course);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Course?> FindCourseByCourseName(string courseName)
        {
            if(courseName.Contains("-")){
                courseName = courseName.Replace("-", " ");
            }

            return await _context.Courses.Include(course => course.CategoryCourses)
                                            .ThenInclude(cateCourse => cateCourse.Category)
                                                .ThenInclude(cate => cate.CategoryCourses)
                                        .Include(course => course.Chapters)
                                            .ThenInclude(chapter => chapter.Lectures)
                                        .Include(course => course.Chapters)
                                            .ThenInclude(quiz => quiz.Quizzes)
                                                .ThenInclude(question => question.Questions)
                                        .FirstOrDefaultAsync(course => course.Name.ToLower().Contains(courseName.ToLower()));
        }
    }
}