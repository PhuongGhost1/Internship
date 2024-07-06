using BE.Dto.UserCertification;
using BE.Models;

namespace BE.Services.Interfaces
{
    public interface IUserCertificationService
    {
        

        //---------------------CRUD--------------------------//
        Task<List<UserCertification>> ViewAllUserCertifications();
        Task<UserCertification?> CreateUserCertification(CreateUserCertificationDto createUserCertificationDto);
        Task<UserCertification?> UpdateUserCertification(string userCertificationId, UpdateUserCertificationDto updateUserCertificationDto);
        Task<bool> DeleteUserCertification(string userCertificationId);
    }
}
