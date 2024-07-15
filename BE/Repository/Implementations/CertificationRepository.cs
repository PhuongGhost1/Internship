using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BE.Dto.Category;
using BE.Dto.CategoryCourse;
using BE.Dto.Certification;
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

          public async Task<List<UserCertificationDto>> GetCredentialsByUser(string UserId)
          {
               var credentials = await _context.UserCertifications
                                                       .Where(uc => uc.UserId == UserId)
                                                       .Select(uc => new UserCertificationDto
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
                                                            } : null,
                                                            Certification = uc.Certification != null ? new CertificationDto
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
                                                                                          .Select(cateCourse => new CategoryCourseDto
                                                                                          {
                                                                                               Id = cateCourse.Id,
                                                                                               Category = cateCourse.Category != null ? new CategoryDto
                                                                                               {
                                                                                                    Names = new List<string?> { cateCourse.Category.Name },
                                                                                                    cateId = cateCourse.Category.Id,
                                                                                                    Name = cateCourse.Category.Name
                                                                                               } : null
                                                                                          })
                                                                                          .ToList()
                                                                 } : null
                                                            } : null
                                                       }).ToListAsync();
               return credentials;
          }
     }
}