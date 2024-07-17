using BE.Dto.UserCertification;
using BE.Mappers;
using BE.Models;
using BE.Repository.Interface;
using BE.Services.Interfaces;

namespace BE.Services.Implementations
{
    public class UserCertificationService : IUserCertificationService
    {
        private readonly IUserCertificationRepository _userCertificationRepo;
        private readonly IUserRepository _userRepo;
        public UserCertificationService(IUserCertificationRepository userCertificationRepo, IUserRepository userRepo)
        {
            _userCertificationRepo = userCertificationRepo;
            _userRepo = userRepo;
        }


        //---------------------CRUD--------------------------//
        public async Task<UserCertification?> CreateUserCertification(CreateUserCertificationDto createUserCertificationDto)
        {

            var createUserCertification = createUserCertificationDto.ToCreateUserCertification();

            if (createUserCertification == null) throw new Exception("Unable to create user-certification!");

            return await _userCertificationRepo.CreateUserCertification(createUserCertification);
        }

        public async Task<bool> DeleteUserCertification(string userCertificationId)
        {
            var userCertification = await _userCertificationRepo.GetUserCertificationById(userCertificationId);

            if (userCertification == null) throw new Exception("Unable to find user-certification!");

            return await _userCertificationRepo.DeleteUserCertification(userCertificationId);
        }

        public async Task<UserCertification?> UpdateUserCertification(string userCertificationId, UpdateUserCertificationDto updateUserCertificationDto)
        {
            var userCertification = await _userCertificationRepo.GetUserCertificationById(userCertificationId);

            if (userCertification == null) throw new Exception("Unable to find user-certification!");

            var updateUserCertification = updateUserCertificationDto.ToUpdateUserCertification();

            if (updateUserCertification == null) throw new Exception("Unable to update user-certification!");

            return await _userCertificationRepo.UpdateUserCertification(updateUserCertification);
        }

        public async Task<List<UserCertification>> ViewAllUserCertifications()
        {
            return await _userCertificationRepo.GetAllUserCertifications();
        }
    }
}
