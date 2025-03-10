using BE.Dto.Follow;
using BE.Mappers;
using BE.Models;
using BE.Repository.Interface;
using BE.Services.Interfaces;

namespace BE.Services.Implementations
{
     public class FollowService : IFollowService
     {
          private readonly IFollowRepository _followRepo;
          private readonly IUserRepository _userRepo;
          public FollowService(IFollowRepository followRepo, IUserRepository userRepo)
          {
               _followRepo = followRepo;
               _userRepo = userRepo;
          }
          public async Task<FollowingDto> GetFollowing(string UserId)
          {
               return await _followRepo.GetFollowing(UserId);
          }


          //---------------------CRUD--------------------------//
          public async Task<Follow?> CreateFollow(CreateFollowDto createFollowDto)
          {

               var createFollow = createFollowDto.ToCreateFollow();

               if (createFollow == null) throw new Exception("Unable to create follow!");

               return await _followRepo.CreateFollow(createFollow);
          }

          public async Task<bool> DeleteFollow(CreateFollowDto deleteFollowDto)
          {
               if(deleteFollowDto == null) throw new Exception("Unable to delete follow!");

               var follow = await _followRepo.GetFollowListById(deleteFollowDto.FollowerId, deleteFollowDto.FollowedId);

               if (follow == null) throw new Exception("Unable to find follow!");

               return await _followRepo.DeleteFollow(follow);
          }

          public async Task<Follow?> UpdateFollow(string followId, UpdateFollowDto updateFollowDto)
          {
               var follow = await _followRepo.GetFollowById(followId);

               if (follow == null) throw new Exception("Unable to find follow!");

               var updateFollow = updateFollowDto.ToUpdateFollow();

               if (updateFollow == null) throw new Exception("Unable to update follow!");

               return await _followRepo.UpdateFollow(updateFollow);
          }

          public async Task<List<Follow>> ViewAllFollows()
          {
               return await _followRepo.GetAllFollows();
          }
     }
}
