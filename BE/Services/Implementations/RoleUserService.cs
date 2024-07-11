using BE.Dto.RoleUser;
using BE.Mappers;
using BE.Models;
using BE.Repository.Interface;
using BE.Services.Interfaces;

namespace BE.Services.Implementations
{
    public class RoleUserService : IRoleUserService
    {
        private readonly IRoleUserRepository _roleUserRepo;
        private readonly IUserRepository _userRepo;
        public RoleUserService(IRoleUserRepository roleUserRepo, IUserRepository userRepo)
        {
            _roleUserRepo = roleUserRepo;
            _userRepo = userRepo;
        }


        //---------------------CRUD--------------------------//
        public async Task<RoleUser?> CreateRoleUser(CreateRoleUserDto createRoleUserDto)
        {
            if(createRoleUserDto == null) throw new Exception("Unable to find role User!");

            var createRoleUser = createRoleUserDto.ToCreateRoleUser();

            if(createRoleUser == null) throw new Exception("Unable to create role-user!");

            return await _roleUserRepo.CreateRoleUser(createRoleUser);
        }

        public async Task<bool> DeleteRoleUser(string roleUserId)
        {
            var roleUser = await _roleUserRepo.GetRoleUserById(roleUserId);

            if(roleUser == null) throw new Exception("Unable to find role-user!");

            return await _roleUserRepo.DeleteRoleUser(roleUserId);
        }

        public async Task<bool> RequestForRoleUserAsync(string userId, string roleName)
        {
            var user = await _userRepo.GetUserById(userId);

            if(user == null) throw new Exception("Unable to find user!");

            return await _roleUserRepo.RequestForRoleUser(userId, roleName);
        }

        public async Task<bool> UpdateRequestForRoleUserAsync(string userId, int status)
        {
            var user = await _userRepo.GetUserById(userId);

            if(user == null) throw new Exception("Unable to find user!");

            return await _roleUserRepo.UpdateRequestForRoleUser(userId, status);
        }

        public async Task<RoleUser?> UpdateRoleUser(string roleUserId, UpdateRoleUserDto updateRoleUserDto)
        {
            var roleUser = await _roleUserRepo.GetRoleUserById(roleUserId);

            if(roleUser == null) throw new Exception("Unable to find role-user!");

            var updateRoleUser = updateRoleUserDto.ToUpdateRoleUser();

            if(updateRoleUser == null) throw new Exception("Unable to update role-user!");

            return await _roleUserRepo.UpdateRoleUser(updateRoleUser);
        }

        public async Task<List<RoleUser>> ViewAllRoleUsers()
        {
            return await _roleUserRepo.GetAllRoleUsers();
        }
    }
}