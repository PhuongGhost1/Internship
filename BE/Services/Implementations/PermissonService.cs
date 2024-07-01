using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BE.Models;
using BE.Repository.Interface;
using BE.Services.Interfaces;
using static BE.Utils.Utils;

namespace BE.Services.Implementations
{
    public class PermissonService : IPermissonService
    {
        private readonly IPermissonRepository _permissonRepository;

        public PermissonService(IPermissonRepository permissonRepository)
        {
            _permissonRepository = permissonRepository;
        }

        public async Task<IEnumerable<Permisson>> GetAllPermissonsAsync()
        {
            return await _permissonRepository.GetAllPermissonsAsync();
        }

        public async Task<Permisson> GetPermissonByIdAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new Exception("Permisson ID cannot be null or empty.");
            }

            var permisson = await _permissonRepository.GetPermissonByIdAsync(id);
            if (permisson == null)
            {
                throw new Exception("Permisson not found.");
            }

            return permisson;
        }

        public async Task AddPermissonAsync(Permisson permisson)
        {
            if (permisson == null)
            {
                throw new Exception("Permisson cannot be null.");
            }

            permisson.Id = Utils.Utils.GenerateIdModel("permisson");
            permisson.LastUpdate = Utils.Utils.GetTimeNow();

            await _permissonRepository.AddPermissonAsync(permisson);
        }

        public async Task UpdatePermissonAsync(Permisson permisson)
        {
            if (permisson == null)
            {
                throw new Exception("Permisson cannot be null.");
            }

            var existingPermisson = await _permissonRepository.GetPermissonByIdAsync(permisson.Id);
            if (existingPermisson == null)
            {
                throw new Exception("Permisson not found.");
            }

            permisson.LastUpdate = Utils.Utils.GetTimeNow();

            await _permissonRepository.UpdatePermissonAsync(permisson);
        }

        public async Task DeletePermissonAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new Exception("Permisson ID cannot be null or empty.");
            }

            var permisson = await _permissonRepository.GetPermissonByIdAsync(id);
            if (permisson == null)
            {
                throw new Exception("Permisson not found.");
            }

            await _permissonRepository.DeletePermissonAsync(id);
        }
    }
}
