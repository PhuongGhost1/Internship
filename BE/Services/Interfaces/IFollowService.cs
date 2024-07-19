using BE.Dto.Follow;
using BE.Models;

namespace BE.Services.Interfaces
{
     public interface IFollowService
     {
          Task<FollowingDto> GetFollowing(string UserId);


          //---------------------CRUD--------------------------//
          Task<List<Follow>> ViewAllFollows();
          Task<Follow?> CreateFollow(CreateFollowDto createFollowDto);
          Task<Follow?> UpdateFollow(string followId, UpdateFollowDto updateFollowDto);
          Task<bool> DeleteFollow(CreateFollowDto deleteFollowDto);
     }
}
