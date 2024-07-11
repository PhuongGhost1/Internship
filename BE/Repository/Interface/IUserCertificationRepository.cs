using BE.Models;

namespace BE.Repository.Interface
{
    public interface IUserCertificationRepository
    {
        

        //---------------------CRUD--------------------------//
        Task<UserCertification?> GetUserCertificationById(string userCertificationUserId);
        Task<List<UserCertification>> GetAllUserCertifications();
        Task<UserCertification?> CreateUserCertification(UserCertification userCertificationUser);
        Task<UserCertification?> UpdateUserCertification(UserCertification userCertificationUser);
        Task<bool> DeleteUserCertification(string userCertificationUserId);
    }
}
