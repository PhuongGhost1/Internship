using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BE.Dto.Chapter;
using BE.Dto.Course;
using BE.Dto.Course.Chapter;
using BE.Helpers;
using BE.Dto.Course.Chapter;
using BE.Models;
using BE.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using static BE.Utils.Utils;
using System.Globalization;
using BE.Dto.ImageD;
using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography.X509Certificates;
using BE.Dto.Course.FilterSearchCourse;

namespace BE.Repository.Implementations
{
     public class CourseRepository : ICourseRepository
     {
          private readonly CourseOnlContext _context;
          public CourseRepository(CourseOnlContext context)
          {
               _context = context;
          }

          public async Task<List<Course>> GetAllCourseAvailable()
          {
               return await _context.Courses.Where(c => c.Status == 1).ToListAsync();
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
               Console.WriteLine(courseId);

               var ratingNum = await
                          (from c in _context.Courses
                           join comment in _context.Comments on c.Id equals comment.CourseId
                           where c.Id == courseId
                           select comment)
                          .CountAsync();


               return ratingNum;
          }


          public async Task<string> CreateCourseData(CreateCoursData data)
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

          public async Task<List<Course>> GetCourseWithStatus(string userId, int status)
          {
               var listCourse = await _context.Courses
                 .Where(c => c.UserId == userId && c.Status == status)
                 .ToListAsync();
               return listCourse;
          }


          //---------------------CRUD--------------------------//

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

          public async Task<Course?> FindCourseByCourseName(string courseName)
          {
               return await _context.Courses.Include(course => course.CategoryCourses)
                                               .ThenInclude(cateCourse => cateCourse.Category)
                                           .Include(course => course.User)
                                           .FirstOrDefaultAsync(course => course.Name.Replace(" ", "-").ToLower() == courseName.ToLower());
          }

          public async Task<List<NewReleaseCourseForHomepageDto>> GetMostPurchasedCourses(int count)
          {
               var mostPurchasedCourses = await _context.PaymentCourses
                                                       .Join(_context.CartCourses,
                                                               paymentCourse => paymentCourse.CartcourseId,
                                                               cartCourse => cartCourse.Id,
                                                               (paymentCourse, cartCourse) => new { paymentCourse, cartCourse })
                                                       .Join(_context.Courses,
                                                               combined => combined.cartCourse.CourseId,
                                                               course => course.Id,
                                                               (combined, course) => course)
                                                       .GroupBy(c => c.Id)
                                                       .OrderByDescending(g => g.Count())
                                                       .Select(g => new
                                                       {
                                                            Course = g.First(),
                                                            PurchaseCount = g.Count()
                                                       })
                                                       .Take(count)
                                                       .ToListAsync();

               var mostPurchasedCoursesDto = new List<NewReleaseCourseForHomepageDto>();

               foreach (var c in mostPurchasedCourses)
               {
                    var image = await _context.Images
                         .Where(i => i.CourseId == c.Course.Id && i.Type == "Background")
                         .OrderByDescending(i => i.CreatedAt)
                         .Select(i => new ImageForAdminDto
                         {
                              Id = i.Id,
                              Url = i.Url,
                              Type = i.Type,
                              LastUpdated = i.CreatedAt
                         })
                         .FirstOrDefaultAsync();

                    var ratingAvg = await GetRatingAverage(c.Course.Id) ?? 0;
                    var ratingCount = await GetRatingNumber(c.Course.Id) ?? 0;
                    var totalVideoTime = await CalculateTotalVideoTimeByCourseId(c.Course.Id) ?? 0;
                    var quizCount = await NumberOfQuizInChapterByCourseId(c.Course.Id) ?? 0;

                    var mostPurchased = new NewReleaseCourseForHomepageDto
                    {
                         Id = c.Course.Id,
                         Name = c.Course.Name,
                         Image = new List<ImageForAdminDto> { image },
                         Level = c.Course.Level,
                         Price = c.Course.Price,
                         RatingAvg = ratingAvg,
                         RatingCount = ratingCount,
                         TimeLearning = totalVideoTime + quizCount * 30,
                    };

                    mostPurchasedCoursesDto.Add(mostPurchased);
               }

               return mostPurchasedCoursesDto;
          }

          public async Task<List<MonthlyAnalyticsDto>> GetMonthlyExpenseAndRevenue()
          {
               var monthlyData = new List<MonthlyAnalyticsDto>();

               for (int month = 1; month <= 12; month++)
               {
                    var startDate = new DateTime(DateTime.UtcNow.Year, month, 1);
                    var endDate = startDate.AddMonths(1).AddTicks(-1);

                    var expense = await _context.Payments
                                            .Where(p => p.CreateDate >= startDate && p.CreateDate <= endDate)
                                            .SumAsync(p => p.Total);

                    var revenue = await _context.EnrollCourses
                                                .Where(e => e.Date >= startDate && e.Date <= endDate)
                                                .Join(_context.Courses,
                                                    enroll => enroll.CourseId,
                                                    course => course.Id,
                                                    (enroll, course) => course.Price)
                                                .SumAsync();

                    monthlyData.Add(new MonthlyAnalyticsDto
                    {
                         Month = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month),
                         Expense = expense,
                         Revenue = revenue
                    });
               }

               return monthlyData;
          }

          public async Task<List<CourseManagementForAdminDto>> GetCourseManagementByAdmin()
          {
               var courses = await _context.Courses
                                   .Where(c => c.Status == 0 || c.Status == 1)
                                   .Select(c => new CourseManagementForAdminDto
                                   {
                                        Id = c.Id,
                                        Name = c.Name,
                                        Username = c.User != null ? c.User.Username : null,
                                        Phone = c.User != null ? c.User.Phone : null,
                                        Email = c.User != null ? c.User.Email : null,
                                        Status = c.Status,
                                        CreateAt = c.CreateAt,
                                        UpdateAt = c.UpdateAt,
                                        WhatLearn = c.WhatLearn,
                                        Images = c.Images
                                                   .OrderByDescending(i => i.CreatedAt)
                                                   .Select(i => new ImageForAdminDto
                                                   {
                                                        Id = i.Id,
                                                        Url = i.Url,
                                                        Type = i.Type,
                                                        LastUpdated = i.CreatedAt
                                                   })
                                                   .Take(1)
                                                   .ToList()
                                   }).ToListAsync();

               return courses;
          }

          public async Task<List<CourseManagementForAdminDto>> GetCourseManagementForWaitingByAdmin()
          {
               var courses = await _context.Courses
                                   .Where(c => c.Status == 2)
                                   .Select(c => new CourseManagementForAdminDto
                                   {
                                        Id = c.Id,
                                        Name = c.Name,
                                        Username = c.User != null ? c.User.Username : null,
                                        Phone = c.User != null ? c.User.Phone : null,
                                        Email = c.User != null ? c.User.Email : null,
                                        Status = c.Status,
                                        CreateAt = c.CreateAt,
                                        UpdateAt = c.UpdateAt,
                                        WhatLearn = c.WhatLearn,
                                        Images = c.Images
                                                   .OrderByDescending(i => i.CreatedAt)
                                                   .Select(i => new ImageForAdminDto
                                                   {
                                                        Id = i.Id,
                                                        Url = i.Url,
                                                        Type = i.Type,
                                                        LastUpdated = i.CreatedAt
                                                   })
                                                   .Take(1)
                                                   .ToList()
                                   }).ToListAsync();

               return courses;
          }

          public async Task<bool> UpdateCourseByAdmin(string courseId, int status)
          {
               var course = await _context.Courses.FindAsync(courseId);

               if (course == null) return false;

               course.Status = status;

               _context.Courses.Update(course);

               await _context.SaveChangesAsync();

               return true;
          }

          public async Task<TimeSpan?> TimeLearningCourse(string courseId)
          {
               var course = await _context.Courses
                                               .Include(c => c.Chapters)
                                               .ThenInclude(ch => ch.Lectures)
                                               .FirstOrDefaultAsync(c => c.Id == courseId);
               TimeSpan? totalVideoTime = TimeSpan.Zero;
               foreach (var chapter in course.Chapters)
               {
                    foreach (var lecture in chapter.Lectures)
                    {
                         totalVideoTime += lecture.TimeVideo;
                    }
                    foreach (var quiz in chapter.Quizzes)
                    {
                         totalVideoTime += TimeSpan.FromMinutes(30);
                    }
               }
               return totalVideoTime;
          }

          public async Task<string?> GetImageCourse(string courseId, string type)
          {
               var course = await _context.Courses
                                               .Include(c => c.Images)
                                               .FirstOrDefaultAsync(c => c.Id == courseId);
               string imgUrl = "";
               foreach (var img in course.Images)
               {
                    if (img.Type == type)
                    {
                         imgUrl = img.Url;
                    }
               }
               return imgUrl;
          }
          public async Task<List<Course>> SearchingCourse(string query)
          {
               var courses = await GetAllCourseAvailable();

               if (!string.IsNullOrEmpty(query))
               {
                    string lowerQuery = query.ToLower();
                    courses = courses.Where(c => c.Name.ToLower().Contains(lowerQuery))
                                     .OrderByDescending(c => c.Name.ToLower().StartsWith(lowerQuery))
                                     .ThenBy(c => c.Name.ToLower())
                                     .ToList();
               }
               return courses;
          }

          public async Task<int> CountLectureCourse(string courseId)
          {
               var lectureCount = await _context.Lectures
                                   .Where(l => l.Chapter.CourseId == courseId)
                                   .CountAsync();
               return lectureCount;
          }

          public async Task<List<NewReleaseCourseForHomepageDto>> NewReleaseCourses(int count)
          {
               var newReleaseCourses = await _context.Courses
                    .OrderByDescending(c => c.CreateAt)
                    .Take(count)
                    .ToListAsync();

               var newReleaseCoursesDto = new List<NewReleaseCourseForHomepageDto>();

               foreach (var c in newReleaseCourses)
               {
                    var image = await _context.Images
                         .Where(i => i.CourseId == c.Id && i.Type == "Background")
                         .OrderByDescending(i => i.CreatedAt)
                         .Select(i => new ImageForAdminDto
                         {
                              Id = i.Id,
                              Url = i.Url,
                              Type = i.Type,
                              LastUpdated = i.CreatedAt
                         })
                         .FirstOrDefaultAsync();

                    var ratingAvg = await GetRatingAverage(c.Id) ?? 0;
                    var ratingCount = await GetRatingNumber(c.Id) ?? 0;
                    var totalVideoTime = await CalculateTotalVideoTimeByCourseId(c.Id) ?? 0;
                    var quizCount = await NumberOfQuizInChapterByCourseId(c.Id) ?? 0;

                    var newRelease = new NewReleaseCourseForHomepageDto
                    {
                         Id = c.Id,
                         Name = c.Name,
                         Image = new List<ImageForAdminDto> { image },
                         Level = c.Level,
                         Price = c.Price,
                         RatingAvg = ratingAvg,
                         RatingCount = ratingCount,
                         TimeLearning = totalVideoTime + quizCount * 30,
                    };

                    newReleaseCoursesDto.Add(newRelease);
               }

               return newReleaseCoursesDto;
          }

          private async Task<float?> GetRatingAverage(string courseId)
          {
               using (var context = new CourseOnlContext())
               {
                    var ratingAvg = await (from c in context.Courses
                                           join ec in context.EnrollCourses on c.Id equals ec.CourseId
                                           join comment in context.Comments on c.Id equals comment.CourseId
                                           where c.Id == courseId
                                           select comment.Rating)
                                        .AverageAsync();

                    return (float?)ratingAvg;
               }
          }

          private async Task<int?> GetRatingNumber(string courseId)
          {
               using (var context = new CourseOnlContext())
               {
                    var ratingNum = await (from c in context.Courses
                                           join comment in context.Comments on c.Id equals comment.CourseId
                                           where c.Id == courseId
                                           select comment)
                                        .CountAsync();

                    return ratingNum;
               }
          }

          public async Task<int?> NumberOfQuizInChapterByCourseId(string courseId)
          {
               using (var context = new CourseOnlContext())
               {
                    var quizCountByChapter = await (from chap in context.Chapters
                                                    join c in context.Courses on chap.CourseId equals c.Id
                                                    join q in context.Quizzes on chap.Id equals q.ChapterId into quizGroup
                                                    where c.Id == courseId
                                                    select new
                                                    {
                                                         ChapterId = chap.Id,
                                                         QuizCount = quizGroup.Count()
                                                    })
                                                  .ToListAsync();

                    return quizCountByChapter.Sum(x => x.QuizCount);
               }
          }

          public async Task<int?> CalculateTotalVideoTimeByCourseId(string courseId)
          {
               using (var context = new CourseOnlContext())
               {
                    var totalVideoTimeMinutes = await (from chap in context.Chapters
                                                       join c in context.Courses on chap.CourseId equals c.Id
                                                       join l in context.Lectures on chap.Id equals l.ChapterId
                                                       where c.Id == courseId
                                                       select l.TimeVideo)
                                                  .ToListAsync();

                    int sumTotalMinutes = totalVideoTimeMinutes.Sum(timeOnly => ToMinutes(timeOnly));

                    return sumTotalMinutes;
               }
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


          public async Task<List<NewReleaseCourseForHomepageDto>> GetTopRatedCourses(int count)
          {
               var topRatedCourses = await _context.Courses
                    .OrderByDescending(c => c.Rating)
                    .Take(count)
                    .ToListAsync();

               var topRatedCoursesDto = new List<NewReleaseCourseForHomepageDto>();

               foreach (var c in topRatedCourses)
               {
                    var image = await _context.Images
                         .Where(i => i.CourseId == c.Id && i.Type == "Background")
                         .OrderByDescending(i => i.CreatedAt)
                         .Select(i => new ImageForAdminDto
                         {
                              Id = i.Id,
                              Url = i.Url,
                              Type = i.Type,
                              LastUpdated = i.CreatedAt
                         })
                         .FirstOrDefaultAsync();

                    var ratingAvg = c.Rating ?? 0;
                    var ratingCount = await GetRatingNumber(c.Id) ?? 0;
                    var totalVideoTime = await CalculateTotalVideoTimeByCourseId(c.Id) ?? 0;
                    var quizCount = await NumberOfQuizInChapterByCourseId(c.Id) ?? 0;

                    var topRated = new NewReleaseCourseForHomepageDto
                    {
                         Id = c.Id,
                         Name = c.Name,
                         Image = new List<ImageForAdminDto> { image },
                         Level = c.Level,
                         Price = c.Price,
                         RatingAvg = ratingAvg,
                         RatingCount = ratingCount,
                         TimeLearning = totalVideoTime + quizCount * 30,
                    };

                    topRatedCoursesDto.Add(topRated);
               }

               return topRatedCoursesDto;
          }

          public async Task<bool> CreateCourse(Course course)
          {
               _context.Courses.Add(course);
               await _context.SaveChangesAsync();
               return true;
          }

          public async Task<Cart?> GetCart(string userId)
          {
               return await _context.Carts.Where(c => c.UserId == userId).FirstOrDefaultAsync();
          }

          public async Task CreateCart(string userId)
          {
               _context.Carts.Add(new Cart
               {
                    Id = GenerateIdModel("cart"),
                    UserId = userId,
                    DateCreated = GetTimeNow(),
                    Total = 0,
                    Status = 1
               });
               await _context.SaveChangesAsync();
          }
          public async Task AddCourseToCart(Cart? cart, string courseId)
          {
               Course? course = await _context.Courses.Where(c => c.Id == courseId).FirstOrDefaultAsync();
               _context.CartCourses.Add(new CartCourse
               {
                    Id = GenerateIdModel("cartcourse"),
                    Cart = cart,
                    CourseId = courseId,
                    CreatedAt = GetTimeNow(),
                    Total = course.Price,
                    Status = 1,
               });
               cart.Total += course.Price;
               _context.Carts.Update(cart);
               await _context.SaveChangesAsync();
          }
          public async Task<List<CartCourse>> GetListCartCourse(Cart cart)
          {
               List<CartCourse> cartCourse = await _context.CartCourses
                                             .Include(cc => cc.Course)
                                             .Include(cc => cc.PaymentCourse)
                                             .Include(cc => cc.AffiliatePayment)
                                             .Where(cc => cc.Cart == cart && cc.AffiliatePayment == null && cc.PaymentCourse == null)
                                             .ToListAsync();
               return cartCourse;
          }
          public async Task DeleteCartCoure(CartCourse cartCourse)
          {
               _context.CartCourses.Remove(cartCourse);
               await _context.SaveChangesAsync();
          }

          public async Task<List<CartCourse>> GetListCartCourseByListId(List<string> cartCourseIds)
          {
               var cartCourses = await _context.CartCourses
                                   .Include(cc => cc.Affiliate)
                                    .Where(cc => cartCourseIds.Contains(cc.Id))
                                    .ToListAsync();
               return cartCourses;
          }

          public async Task<ImageForAdminDto> GetImageForAdminDto(string courseId)
          {
               var image = await _context.Images
                         .Where(i => i.CourseId == courseId && i.Type == "Background")
                         .OrderByDescending(i => i.CreatedAt)
                         .Select(i => new ImageForAdminDto
                         {
                              Id = i.Id,
                              Url = i.Url,
                              Type = i.Type,
                              LastUpdated = i.CreatedAt
                         })
                         .FirstOrDefaultAsync();
               return image;
          }

          public async Task<List<Course>> FilterCourse(List<Course> courses, InputFilterSearchDto dto)
          {
               var filterCourses = courses.AsQueryable();
               //filter through Price Range
               if (dto.PriceRange != null && dto.PriceRange.Count == 2)
               {
                    var minPrice = dto.PriceRange[0];
                    var maxPrice = dto.PriceRange[1];
                    filterCourses = filterCourses.Where(course => course.Price >= minPrice && course.Price <= maxPrice);
               }
               // filter through rating
               if (dto.Ratings != null && dto.Ratings.Any(r => r.IsSelected))
               {
                    var selectedRating = dto.Ratings.Where(r => r.IsSelected).Select(r => r.StarCount).ToList();
                    filterCourses = filterCourses.Where(course => course.Rating.HasValue && selectedRating.Contains((int)Math.Ceiling(course.Rating.Value)));
               }
               //filter through
               if (dto.Levels != null && dto.Levels.Any(r => r.IsSelected))
               {
                    var selectedLevel = dto.Levels.Where(l => l.IsSelected).Select(l => l.Name);
                    filterCourses = filterCourses.Where(course => selectedLevel.Contains(course.Level));
               }
               //filter categories
               if (dto.Categories != null && dto.Categories.Count() > 0)
               {
                    Console.WriteLine("Categories count:" + dto.Categories.Count());
                    var newFilterCourse = new List<Course>();
                    foreach (var course in filterCourses.ToList()) // Convert to List to support async
                    {
                         var categoriescourse = await GetListCategoriesIdByCourse(course.Id);
                         if (categoriescourse != null && categoriescourse.Any(dto.Categories.Contains))
                         {
                              newFilterCourse.Add(course);
                         }
                    }
                    filterCourses = newFilterCourse.AsQueryable();
               }
               return await Task.FromResult(filterCourses.ToList());
          }

          private async Task<List<string?>> GetListCategoriesIdByCourse(string courseId)
          {
               return await _context.CategoryCourses.Where(cc => cc.CourseId == courseId)
                                                   .Select(cc => cc.CategoryId)
                                                   .ToListAsync();
          }

          public async Task<bool> CheckSavedCourse(string courseId, string userId)
          {
               var coursesId = await _context.SaveCourses.Where(sv => sv.UserId == userId)
                                                            .Select(sv => sv.CourseId)
                                                            .ToListAsync();
               return coursesId.Contains(courseId);
          }
          public async Task<int> CountEnrollCourse(string courseId)
          {
               return await _context.EnrollCourses.Where(ec => ec.CourseId == courseId)
                                                  .CountAsync();
          }
          public async Task AddVideoToLecture(string courseId, int chapterIndex, int lectureIndex, IFormFile video)
          {
               var chapter = await _context.Chapters.Where(c => c.CourseId == courseId && c.Index == chapterIndex).FirstOrDefaultAsync();
               var lecture = await _context.Lectures.Where(l => l.Chapter == chapter && l.Index == lectureIndex).FirstOrDefaultAsync();
               var courseName = (await RetriveCourseInformationById(courseId))?.Name?.Replace(" ", "-");
               lecture.VideoUrl = await UploadVideoToFirebase(video, courseName, chapterIndex, lectureIndex);
               _context.Lectures.Update(lecture);
               await _context.SaveChangesAsync();
          }
     }
}