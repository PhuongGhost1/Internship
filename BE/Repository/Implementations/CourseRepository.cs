using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BE.Dto.Course;
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
        public async Task<List<Course>> GetAllCourses()
        {
            return await _context.Courses.ToListAsync();
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
                var imgAvatar = new Image
                {
                    Id = GenerateIdModel("image"),
                    CourseId = courseId,
                    CreatedAt = GetTimeNow(),
                    Url = await UploadImgToFirebase(data.Avatar, GetNameUnderscore(data.Name), "Avatar"),
                    Type = "Avatar"
                };
                var imgBackground = new Image
                {
                    Id = GenerateIdModel("image"),
                    CourseId = courseId,
                    CreatedAt = GetTimeNow(),
                    Url = await UploadImgToFirebase(data.Background, GetNameUnderscore(data.Name), "Background"),
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
    }
}