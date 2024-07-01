using System.Collections.Generic;
using System.Threading.Tasks;
using BE.Models;

namespace BE.Services.Interfaces
{
    public interface IFollowService
    {
        Task<IEnumerable<Follow>> GetAllFollowsAsync();
        Task<Follow> GetFollowByIdAsync(string id);
        Task AddFollowAsync(Follow role);
        Task UpdateFollowAsync(Follow role);
        Task DeleteFollowAsync(string id);
    }
}
