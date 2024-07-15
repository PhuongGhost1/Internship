
using BE.Dto.Certification;
using BE.Dto.UserCertification;
using BE.Models;

namespace BE.Repository.Interface
{
     public interface ICertificationRepository
     {
          Task<List<UserCertificationDto>> GetCredentialsByUser(string UserId);

          //---------------------CRUD--------------------------//
          Task<List<Certification>> GetAllCertifications();
          Task<Certification?> CreateCertification(Certification certification);
     }
}