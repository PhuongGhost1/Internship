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
using BE.Dto.User;
using BE.Dto.UserCertification;
using BE.Models;
using BE.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace BE.Repository.Implementations
{
     public class CertificationRepository : ICertificationRepository
     {
          private readonly CourseOnlContext _context;

          public CertificationRepository(CourseOnlContext context)
          {
               _context = context;
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
     }
}