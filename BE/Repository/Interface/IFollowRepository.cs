using BE.Dto.Follow;
using BE.Models;

namespace BE.Repository.Interface
{
     public interface IFollowRepository
     {
          Task<FollowingDto> GetFollowing(string UserId);
          Task<Follow?> GetFollowListById(string followerId, string followedId);

          //---------------------CRUD--------------------------//
          Task<Follow?> GetFollowById(string followId);
          Task<List<Follow>> GetAllFollows();
          Task<Follow?> CreateFollow(Follow followUser);
          Task<Follow?> UpdateFollow(Follow followUser);
          Task<bool> DeleteFollow(Follow followUser);
     }
}
