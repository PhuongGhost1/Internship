using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BE.Dto.Certification;
using BE.Dto.InProgressDto;
using BE.Dto.UserCertification;
using BE.Mappers;
using BE.Models;
using BE.Repository.Interface;
using BE.Services.Interfaces;

namespace BE.Services.Implementations
{
     public class CertificationService : ICertificationService
     {
          private readonly ICertificationRepository _certiRepo;
          private readonly ICourseRepository _courseRepo;
          private readonly IUserRepository _userRepo;
          public CertificationService(ICertificationRepository certiRepo, ICourseRepository courseRepo, IUserRepository userRepo)
          {
               _certiRepo = certiRepo;
               _courseRepo = courseRepo;
               _userRepo = userRepo;
          }


          //---------------------CRUD--------------------------//
          public async Task<Certification?> CreateCertification(CreateCertificatonDto createCertificatonDto)
          {
               var course = await _courseRepo.RetriveCourseInformationById(createCertificatonDto.CourseId);

               if (course == null) throw new Exception("Unable to find course!");

               var createCertification = createCertificatonDto.ToCreateCertificationDto(createCertificatonDto.CourseId);

               if (createCertification == null) throw new Exception("Unable to create course!");

               return await _certiRepo.CreateCertification(createCertification);
          }

          public async Task<List<Certification>> ViewAllCertifications()
          {
               return await _certiRepo.GetAllCertifications();
          }

          public async Task<List<UserCertificationDto>> GetCredentialsByUserAsync(string UserId)
          {
               var user = await _userRepo.GetUserById(UserId);

               if (user == null) return new List<UserCertificationDto>();

               return await _certiRepo.GetCredentialsByUser(UserId);
          }

          public async Task<List<UserPurchasedCourseDto>> GetUserPurchasedCoursesWithDetailsAsync(string userId)
          {
               var user = await _userRepo.GetUserById(userId);

               if (user == null) return new List<UserPurchasedCourseDto>();

               return await _certiRepo.GetUserPurchasedCoursesWithDetails(userId);
          }
    }
}