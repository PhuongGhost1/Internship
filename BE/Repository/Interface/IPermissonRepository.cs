using System.Collections.Generic;
using System.Threading.Tasks;
using BE.Models;

namespace BE.Repository.Interface
{
    public interface IPermissonRepository
    {
        Task<IEnumerable<Permisson>> GetAllPermissonsAsync();
        Task<Permisson> GetPermissonByIdAsync(string id);
        Task AddPermissonAsync(Permisson permisson);
        Task UpdatePermissonAsync(Permisson permisson);
        Task DeletePermissonAsync(string id);
    }
}
