using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BE.Models;
using BE.Repository.Interface;
using BE.Services.Interfaces;
using BE.Utils;

namespace BE.Services.Implementations
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<IEnumerable<Role>> GetAllRolesAsync()
        {
            return await _roleRepository.GetAllRolesAsync();
        }

        public async Task<Role> GetRoleByIdAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new Exception("Role ID cannot be null or empty.");
            }

            var role = await _roleRepository.GetRoleByIdAsync(id);
            if (role == null)
            {
                throw new Exception("Role not found.");
            }

            return role;
        }

        public async Task AddRoleAsync(Role role)
        {
            if (role == null)
            {
                throw new Exception("Role cannot be null.");
            }
            role.Id = Utils.Utils.GenerateIdModel("Role");
            await _roleRepository.AddRoleAsync(role);
        }

        public async Task UpdateRoleAsync(Role role)
        {
            if (role == null)
            {
                throw new Exception("Role cannot be null.");
            }

            var existingRole = await _roleRepository.GetRoleByIdAsync(role.Id);
            if (existingRole == null)
            {
                throw new Exception("Role not found.");
            }

            await _roleRepository.UpdateRoleAsync(role);
        }

        public async Task DeleteRoleAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new Exception("Role ID cannot be null or empty.");
            }

            var role = await _roleRepository.GetRoleByIdAsync(id);
            if (role == null)
            {
                throw new Exception("Role not found.");
            }

            await _roleRepository.DeleteRoleAsync(id);
        }
    }
}
