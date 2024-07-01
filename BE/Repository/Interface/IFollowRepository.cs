using System.Collections.Generic;
using System.Threading.Tasks;
using BE.Models;

namespace BE.Repository.Interface
{
    public interface IFollowRepository
    {
        Task<IEnumerable<Follow>> GetAllFollowsAsync();
        Task<Follow> GetFollowByIdAsync(string id);
        Task AddFollowAsync(Follow follow);
        Task UpdateFollowAsync(Follow follow);
        Task DeleteFollowAsync(string id);
    }
}
