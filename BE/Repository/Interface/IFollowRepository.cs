using BE.Models;

namespace BE.Repository.Interface
{
    public interface IFollowRepository
    {
        

        //---------------------CRUD--------------------------//
        Task<Follow?> GetFollowById(string followUserId);
        Task<List<Follow>> GetAllFollows();
        Task<Follow?> CreateFollow(Follow followUser);
        Task<Follow?> UpdateFollow(Follow followUser);
        Task<bool> DeleteFollow(string followUserId);
    }
}
