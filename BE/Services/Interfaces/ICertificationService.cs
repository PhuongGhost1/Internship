using BE.Dto.Certification;
using BE.Dto.InProgressDto;
using BE.Dto.UserCertification;
using BE.Models;

namespace BE.Services.Interfaces
{
     public interface ICertificationService
     {
          Task<List<UserPurchasedCourseDto>> GetUserPurchasedCoursesWithDetailsAsync(string userId);

          //---------------------CRUD--------------------------//
          Task<List<Certification>> ViewAllCertifications();
          Task<Certification?> CreateCertification(CreateCertificatonDto createCertificatonDto);
          Task<List<UserCertificationDto>> GetCredentialsByUserAsync(string UserId);
     }
}