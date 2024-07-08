using BE.Dto.Role;
using BE.Mappers;
using BE.Models;
using BE.Repository.Interface;
using BE.Services.Interfaces;

namespace BE.Services.Implementations
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepo;
        private readonly IUserRepository _userRepo;
        private readonly IRoleUserRepository _userRoleRepo;
        public RoleService(IRoleRepository roleRepo, IUserRepository userRepo, IRoleUserRepository userRoleRepo)
        {
            _roleRepo = roleRepo;
            _userRepo = userRepo;
            _userRoleRepo = userRoleRepo;
        }

        public async Task<IEnumerable<string?>> GetUserRoleAsync(string userId)
        {
            var user = await _userRepo.GetUserById(userId);

            if(user == null) throw new Exception("Unable to find user!");

            return await _userRoleRepo.GetUserRole(userId);
        }
        
        //---------------------CRUD--------------------------//
        public async Task<Role?> CreateRole( CreateRoleDto createRoleDto)
        {

            var createRole = createRoleDto.ToCreateRole();

            if(createRole == null) throw new Exception("Unable to create role-user!");

            return await _roleRepo.CreateRole(createRole);
        }

        public async Task<bool> DeleteRole(string roleId)
        {
            var role = await _roleRepo.GetRoleById(roleId);

            if(role == null) throw new Exception("Unable to find role-user!");

            return await _roleRepo.DeleteRole(roleId);
        }

        public async Task<Role?> UpdateRole(string roleId, UpdateRoleDto updateRoleDto)
        {
            var role = await _roleRepo.GetRoleById(roleId);

            if(role == null) throw new Exception("Unable to find role-user!");

            var updateRole = updateRoleDto.ToUpdateRole();

            if(updateRole == null) throw new Exception("Unable to update role-user!");

            return await _roleRepo.UpdateRole(updateRole);
        }

        public async Task<List<Role>> ViewAllRoles()
        {
            return await _roleRepo.GetAllRoles();
        }
    }
}
