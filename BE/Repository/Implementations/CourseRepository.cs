using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BE.Dto.Course;
using BE.Helpers;
using BE.Dto.Course.Chapter;
using BE.Models;
using BE.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
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

            if (!string.IsNullOrWhiteSpace(searchQueryObject.Name))
            {
                courses = _context.Courses.Where(c => c.Name.Contains(searchQueryObject.Name));
            }

            return await courses.ToListAsync();
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
                var imgAvatar = new Image
                {
                    Id = GenerateIdModel("image"),
                    CourseId = courseId,
                    CreatedAt = GetTimeNow(),
                    Url = await UploadImgCourseToFirebase(data.Avatar, GetNameUnderscore(data.Name), "Avatar"),
                    Type = "Avatar"
                };
                var imgBackground = new Image
                {
                    Id = GenerateIdModel("image"),
                    CourseId = courseId,
                    CreatedAt = GetTimeNow(),
                    Url = await UploadImgCourseToFirebase(data.Background, GetNameUnderscore(data.Name), "Background"),
                    Type = "Background"
                };
                _context.Images.Add(imgAvatar);
                _context.Images.Add(imgBackground);
                await _context.SaveChangesAsync();
                return courseId;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi tạo khóa học: {ex.Message}");
                return "error";
            }
        }
        public async Task<string> CreateChapter(CreateChapterData data)
        {
            try
            {
                var json = new Dictionary<string, string>();
                string chapterId = GenerateIdModel("chapter");
                var chapter = new Chapter
                {
                    Id = chapterId,
                    Index = data.Index,
                    CourseId = data.CourseId,
                    Name = data.NameChapter,
                    CreateAt = GetTimeNow(),
                    Status = 1
                };
                _context.Chapters.Add(chapter);
                int count = 1;
                string input = data.ItemsName;
                string[] parts = input.Split(new string[] { "; " }, StringSplitOptions.None);
                List<string> resultList = new List<string>(parts);
                foreach (string item in resultList)
                {
                    int quizCount = 1;
                    if (item.Contains("Lecture: "))
                    {
                        string lectureName = item.Replace("Lecture: ", "");
                        Random random = new Random();
                        int randomMinutes = random.Next(3, 10);
                        int randomSeconds = random.Next(0, 60);
                        TimeSpan randomTimeSpan = TimeSpan.FromMinutes(randomMinutes) + TimeSpan.FromSeconds(randomSeconds);
                        string lectureId = GenerateIdModel("lecture");
                        var lecture = new Lecture
                        {
                            Id = lectureId,
                            Index = count,
                            ChapterId = chapterId,
                            Name = lectureName,
                            TimeVideo = randomTimeSpan,
                            CreatAt = GetTimeNow(),
                            Status = 1
                        };
                        _context.Lectures.Add(lecture);
                    }
                    else if (item.Contains("Quiz: "))
                    {
                        string quizName = item.Replace("Quiz: ", "");
                        string quizId = GenerateIdModel("quiz");
                        var quiz = new Quiz
                        {
                            Id = quizId,
                            Index = count,
                            ChapterId = chapterId,
                            Name = quizName,
                            PassPercent = 80,
                            CreateAt = GetTimeNow(),
                            NumberQuestions = 0,
                            TotalMark = 0,
                            Status = 1
                        };
                        json["quiz" + quizCount.ToString()] = quizId;
                        quizCount++;
                        _context.Quizzes.Add(quiz);
                    }
                    count++;
                }
                await _context.SaveChangesAsync();

                string jsonResult = JsonConvert.SerializeObject(json);
                return jsonResult;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi tạo khóa học: {ex.Message}");
                return "error";
            }
        }

        public async Task<string> CreateQuiz(CreateQuizData data)
        {
            try
            {
                string questionId = GenerateIdModel("question");
                var question = new Question
                {
                    Id = questionId,
                    QuizId = data.QuizId,
                    Text = data.Question,
                    Mark = 1,
                    Type = data.Type,
                    CreateAt = GetTimeNow(),
                    Status = 1
                };
                var quiz = await _context.Quizzes.FirstOrDefaultAsync(e => e.Id == data.QuizId);
                quiz.TotalMark = quiz.TotalMark + question.Mark;
                quiz.NumberQuestions = quiz.NumberQuestions + 1;
                _context.Questions.Add(question);
                string input = data.Answers;
                string[] parts = input.Split(new string[] { "; " }, StringSplitOptions.None);
                List<string> resultList = new List<string>(parts);
                foreach (string answer in resultList)
                {
                    if (answer.Contains("(True)"))
                    {
                        string answerName = answer.Replace("(True)", "");
                        var answerData = new Answer
                        {
                            Id = GenerateIdModel("answer"),
                            QuestionId = questionId,
                            Text = answerName,
                            Status = 1,
                            IsCorrect = true,
                            CreatedAt = GetTimeNow()
                        };
                        _context.Answers.Add(answerData);
                    }
                    else
                    {
                        var answerData = new Answer
                        {
                            Id = GenerateIdModel("answer"),
                            QuestionId = questionId,
                            Text = answer,
                            Status = 1,
                            IsCorrect = false,
                            CreatedAt = GetTimeNow()
                        };
                        _context.Answers.Add(answerData);
                    }
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

            if (filterQueryObject.FromPrices > 0 && filterQueryObject.ToPrices > 0 && filterQueryObject.ToPrices > filterQueryObject.FromPrices)
            {
                courses = courses
                            .Where(course => filterQueryObject.FromPrices <= course.Price && course.Price <= filterQueryObject.ToPrices)
                            .OrderByDescending(course => course.Price);
            }

            if (filterQueryObject.Rating > 0)
            {
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

            if (course == null) return false;

            course.Status = 0;

            _context.Courses.Update(course);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}