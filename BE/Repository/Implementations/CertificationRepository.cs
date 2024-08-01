using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BE.Dto.Category;
using BE.Dto.CategoryCourse;
using BE.Dto.Certification;
using BE.Dto.Chapter;
using BE.Dto.Comment;
using BE.Dto.Course;
using BE.Dto.ImageD;
using BE.Dto.InProgressDto;
using BE.Dto.User;
using BE.Dto.UserCertification;
using BE.Models;
using BE.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using static BE.Utils.Utils;

namespace BE.Repository.Implementations
{
     public class CertificationRepository : ICertificationRepository
     {
          private readonly CourseOnlContext _context;

          public CertificationRepository(CourseOnlContext context)
          {
               _context = context;
          }

        public async Task<List<Certification>> GetUserCertifications(string userId)
        {
            throw new NotImplementedException();
        }



        //---------------------CRUD--------------------------//
        public async Task<Certification?> CreateCertification(Certification certification)
        {
            await _context.Certifications.AddAsync(certification);
            await _context.SaveChangesAsync();
            return certification;
        }

        public async Task<List<Certification>> GetAllCertifications()
        {
            return await _context.Certifications.ToListAsync();
        }

          private async Task<int> NumberOfQuizInChapterByCourseId(string courseId)
          {
          var quizCountByChapter = await (from chap in _context.Chapters
                                             join c in _context.Courses on chap.CourseId equals c.Id
                                             join q in _context.Quizzes on chap.Id equals q.ChapterId into quizGroup
                                             where c.Id == courseId
                                             select new
                                             {
                                                  ChapterId = chap.Id,
                                                  QuizCount = quizGroup.Count()
                                             })
                                             .ToListAsync();

          return quizCountByChapter.Sum(x => x.QuizCount);
          }

          public async Task<int> NumberOfLectureInChapterByCourseId(string courseId)
          {
          var totalLectureInChapter = await (from lec in _context.Lectures
                                             join chap in _context.Chapters on lec.ChapterId equals chap.Id
                                             join course in _context.Courses on chap.CourseId equals course.Id
                                             where course.Id == courseId
                                             select lec)
                                             .CountAsync();

          return totalLectureInChapter;
          }

          private async Task<int?> CalculateTotalVideoTimeByCourseId(string courseId)
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

          public async Task<List<UserCertificationDto>> GetCredentialsByUser(string UserId)
          {
          var userCertifications = await _context.UserCertifications
                                                  .Include(uc => uc.User)
                                                       .ThenInclude(u => u.Comments)
                                                  .Include(uc => uc.Certification)
                                                       .ThenInclude(cert => cert.Course)
                                                            .ThenInclude(course => course.User)
                                                  .Include(uc => uc.Certification)
                                                       .ThenInclude(cert => cert.Course)
                                                            .ThenInclude(course => course.Images)
                                                  .Include(uc => uc.Certification)
                                                       .ThenInclude(cert => cert.Course)
                                                            .ThenInclude(course => course.CategoryCourses)
                                                            .ThenInclude(cateCourse => cateCourse.Category)
                                                  .Include(uc => uc.Certification)
                                                       .ThenInclude(cert => cert.Course)
                                                            .ThenInclude(course => course.Chapters)
                                                  .Where(uc => uc.UserId == UserId)
                                                  .ToListAsync();

          var credentials = new List<UserCertificationDto>();

          foreach (var uc in userCertifications)
          {
               var certificationDto = uc.Certification != null ? new CertificationDto
               {
                    Id = uc.Certification.Id,
                    Name = uc.Certification.Name,
                    CreateAt = uc.Certification.CreateAt,
                    Course = uc.Certification.Course != null ? new CourseForAdminDto
                    {
                         Id = uc.Certification.Course.Id,
                         Name = uc.Certification.Course.Name,
                         Rating = uc.Certification.Course.Rating,
                         Price = uc.Certification.Course.Price,
                         Processings = await NumberOfLectureInChapterByCourseId(uc.Certification.Course.Id) +await NumberOfQuizInChapterByCourseId(uc.Certification.Course.Id),
                         EstimatedLearningTime = await CalculateTotalVideoTimeByCourseId(uc.Certification.Course.Id) + await NumberOfQuizInChapterByCourseId(uc.Certification.Course.Id) * 30,
                         Images = uc.Certification.Course.Images
                                   .OrderByDescending(i => i.CreatedAt)
                                   .Select(i => new ImageForAdminDto
                                   {
                                        Id = i.Id,
                                        Url = i.Url,
                                        Type = i.Type,
                                        LastUpdated = i.CreatedAt
                                   })
                                   .Take(1)
                                   .ToList(),
                         CateCoruse = uc.Certification.Course.CategoryCourses
                                             .Where(cateCourse => cateCourse.Category.IsVisible == true)
                                             .Select(cateCourse => new CategoryCourseDto
                                             {
                                                  Id = cateCourse.Id,
                                                  Category = new CategoryDto
                                                  {
                                                       Names = new List<string?> { cateCourse.Category.Name },
                                                       cateId = cateCourse.Category.Id,
                                                       Name = cateCourse.Category.Name,
                                                       IsVisible = cateCourse.Category.IsVisible
                                                  }
                                             })
                                             .ToList(),
                         Chapters = uc.Certification.Course.Chapters
                                             .OrderBy(chap => chap.Index)
                                             .Select(chap => new ChapterItemDto
                                             {
                                                  ChapterId = chap.Id,
                                                  Name = chap.Name,
                                                  Index = chap.Index
                                             })
                                             .ToList(),
                         User = uc.Certification.Course.User != null ? new UserInfoManageByAdminDto
                         {
                              Id = uc.Certification.Course.User.Id,
                              Name = uc.Certification.Course.User.Username,
                              Email = uc.Certification.Course.User.Email,
                              Description = uc.Certification.Course.User.Description,
                              Phone = uc.Certification.Course.User.Phone,
                              CreateAt = uc.Certification.Course.User.CreateAt,
                              Images = uc.Certification.Course.User.Images
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
                         } : null
                    } : null
               } : null;

               var userCertificationDto = new UserCertificationDto
               {
                    Id = uc.Id,
                    DatePass = uc.DatePass,
                    User = uc.User != null ? new UserInfoManageByAdminDto
                    {
                         Id = uc.User.Id,
                         Name = uc.User.Username,
                         Email = uc.User.Email,
                         Description = uc.User.Description,
                         Phone = uc.User.Phone,
                         CreateAt = uc.User.CreateAt,
                         Images = uc.User.Images
                                   .Where(i => i.UserId == uc.User.Id)
                                   .OrderByDescending(i => i.CreatedAt)
                                   .Select(i => new ImageForAdminDto
                                   {
                                        Id = i.Id,
                                        Url = i.Url,
                                        Type = i.Type,
                                        LastUpdated = i.CreatedAt
                                   })
                                   .Take(1)
                                   .ToList(),
                         Comments = uc.User.Comments.Select(comment => new CommentDto
                         {
                              CommentId = comment.Id,
                              CourseId = comment.CourseId,
                              UserId = comment.UserId,
                              Rating = comment.Rating
                         })
                         .ToList()
                    } : null,
                    Certification = certificationDto
               };

               credentials.Add(userCertificationDto);
          }

          return credentials;
          }

          public async Task<List<UserPurchasedCourseDto>> GetUserPurchasedCoursesWithDetails(string userId)
          {
               var purchasedCourses = await _context.PaymentCourses
                    .Include(pc => pc.Cartcourse)
                         .ThenInclude(cc => cc.Course)
                              .ThenInclude(course => course.Chapters)
                    .Include(pc => pc.Cartcourse)
                         .ThenInclude(cc => cc.Course)
                              .ThenInclude(course => course.Certification)
                    .Include(pc => pc.Cartcourse)
                         .ThenInclude(cc => cc.Course)
                              .ThenInclude(course => course.Images)
                    .Include(pc => pc.Cartcourse)
                         .ThenInclude(cc => cc.Course)
                              .ThenInclude(c => c.User)
                    .Include(pc => pc.Cartcourse)
                         .ThenInclude(cc => cc.Course)
                              .ThenInclude(course => course.CategoryCourses)
                                   .ThenInclude(cc => cc.Category)
                    .Include(pc => pc.Payment)
                    .Where(pc => pc.Cartcourse.Cart.UserId == userId && pc.Cartcourse.Status == 1)
                    .ToListAsync();

               var userPurchasedCourses = new List<UserPurchasedCourseDto>();

               foreach (var paymentCourse in purchasedCourses)
               {
                    var course = paymentCourse.Cartcourse.Course;

                    var enrolledCourse = await _context.EnrollCourses
                         .FirstOrDefaultAsync(ec => ec.UserId == userId && ec.CourseId == course.Id);

                    if (enrolledCourse == null)
                    {
                         enrolledCourse = new EnrollCourse
                         {
                              Id = GenerateIdModel("enrollcourse"),
                              UserId = userId,
                              CourseId = course.Id,
                              Date = DateTime.Now
                         };

                         _context.EnrollCourses.Add(enrolledCourse);
                         await _context.SaveChangesAsync();
                    }

                    var chapterIds = course.Chapters.Select(ch => ch.Id).ToList();

                    var lectures = await _context.Lectures
                         .Where(l => chapterIds.Contains(l.ChapterId))
                         .Select(l => new ChapterItemDto
                         {
                              ItemId = l.Id,
                              Name = l.Name,
                              Index = l.Index,
                              Type = "Lecture",
                              ChapterId = l.ChapterId,
                              HashCode = GenerateHashCode(l.Id),
                              Time = l.TimeVideo
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
                              ChapterId = q.ChapterId,
                              HashCode = GenerateHashCode(q.Id),
                              Time = TimeSpan.FromMinutes(30)
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
                              .ToList(),
                         LectureCount = lectures.Count(l => l.ChapterId == ch.Id),
                         QuizCount = quizzes.Count(q => q.ChapterId == ch.Id),
                         TotalTime = Math.Round(lectures.Where(l => l.ChapterId == ch.Id).Sum(l => l.Time?.TotalMinutes ?? 0) +
                              quizzes.Where(q => q.ChapterId == ch.Id).Sum(q => q.Time?.TotalMinutes ?? 0), 2)
                    }).OrderBy(x => x.Index).ToList();

                    var lectureIds = lectures.Select(l => l.ItemId).ToList();
                    var quizIds = quizzes.Select(q => q.ItemId).ToList();

                    var processingLectures = await _context.Processings
                         .Where(p => p.UserId == userId && lectureIds.Contains(p.LectureId))
                         .Select(p => p.LectureId)
                         .ToListAsync();

                    var processingQuizzes = await _context.Processings
                         .Where(p => p.UserId == userId && quizIds.Contains(p.QuizId))
                         .Select(p => p.QuizId)
                         .ToListAsync();

                    var userProgress = chapterDtos.Select(ch => new UserProgressDto
                    {
                         ChapterId = ch.Id,
                         ChapterName = ch.Name,
                         LectureCount = ch.LectureCount,
                         QuizCount = ch.QuizCount,
                         CompletedLectures = processingLectures.Count(l => lectures.Any(item => item.ItemId == l && item.ChapterId == ch.Id)),
                         CompletedQuizzes = processingQuizzes.Count(q => quizzes.Any(item => item.ItemId == q && item.ChapterId == ch.Id)),
                         TotalTime = ch.TotalTime,
                         CompletedTime = Math.Round(lectures.Where(l => processingLectures.Contains(l.ItemId)).Sum(l => l.Time?.TotalMinutes ?? 0) +
                              quizzes.Where(q => processingQuizzes.Contains(q.ItemId)).Sum(q => q.Time?.TotalMinutes ?? 0), 2)
                    }).ToList();

                    var totalCourseTime = userProgress.Sum(up => up.TotalTime);
                    var totalCompletedTime = userProgress.Sum(up => up.CompletedTime);
                    var completionPercentage = (totalCompletedTime / totalCourseTime) * 100;

                    UserCertificationDto certificationDto = null;

                    if (completionPercentage >= 100 && course.Certification != null)
                    {
                         var certification = await _context.Certifications
                              .FirstOrDefaultAsync(c => c.Id == course.Certification.Id);

                         if (certification == null)
                         {
                              certification = new Certification
                              {
                                   Id = GenerateIdModel("certification"),
                                   CourseId = course.Id,
                                   Name = course.Name,
                                   CreateAt = DateTime.Now
                              };

                              _context.Certifications.Add(certification);
                              await _context.SaveChangesAsync();
                         }

                         var existingCertification = await _context.UserCertifications
                              .FirstOrDefaultAsync(uc => uc.UserId == userId && uc.CertificationId == certification.Id);

                         if (existingCertification == null)
                         {
                              var userCertification = new UserCertification
                              {
                                   Id = GenerateIdModel("usercertification"),
                                   UserId = userId,
                                   CertificationId = certification.Id,
                                   DatePass = DateTime.Now
                              };

                              _context.UserCertifications.Add(userCertification);
                              await _context.SaveChangesAsync();

                              certificationDto = new UserCertificationDto
                              {
                                   Id = userCertification.Id,
                                   User = new UserInfoManageByAdminDto{
                                        Id = userId
                                   },
                                   Certification = new CertificationDto{
                                        Id = certification.Id,
                                        Name = certification.Name,
                                        CreateAt = certification.CreateAt
                                   },
                                   DatePass = userCertification.DatePass
                              };
                         }
                    }

                    var purchasedCourseDto = new UserPurchasedCourseDto
                    {
                         CourseId = course.Id,
                         CourseName = course.Name,
                         Chapters = chapterDtos,
                         UserProgress = userProgress,
                         UserCertifications = certificationDto != null ? new List<UserCertificationDto> { certificationDto } : new List<UserCertificationDto>(),
                         Images = course.Images
                                   .OrderByDescending(i => i.CreatedAt)
                                   .Select(i => new ImageForAdminDto
                                   {
                                        Id = i.Id,
                                        Url = i.Url,
                                        Type = i.Type,
                                        LastUpdated = i.CreatedAt
                                   })
                                   .Take(1)
                                   .ToList(),
                         CateCoruse = course.CategoryCourses
                                             .Where(cateCourse => cateCourse.Category.IsVisible == true)
                                             .Select(cateCourse => new CategoryCourseDto
                                             {
                                                  Id = cateCourse.Id,
                                                  Category = new CategoryDto
                                                  {
                                                       Names = new List<string?> { cateCourse.Category.Name },
                                                       cateId = cateCourse.Category.Id,
                                                       Name = cateCourse.Category.Name,
                                                       IsVisible = cateCourse.Category.IsVisible
                                                  }
                                             })
                                             .ToList(),
                         User = course.User != null ? new UserInfoManageByAdminDto
                         {
                              Id = course.User.Id,
                              Name = course.User.Username,
                              Email = course.User.Email,
                              Description = course.User.Description,
                              Phone = course.User.Phone,
                              CreateAt = course.User.CreateAt,
                              Images = course.User.Images
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
                         } : null
                    };

                    userPurchasedCourses.Add(purchasedCourseDto);
               }

               return userPurchasedCourses;
          }
    }
}