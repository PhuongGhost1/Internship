using BE.Dto.Follow;
using BE.Models;
using static BE.Utils.Utils;

namespace BE.Mappers
{
    public static class FollowMappers
    {
        public static Follow ToCreateFollow(this CreateFollowDto createFollowDto){
            return new Follow{
                Id = GenerateIdModel("enrollcourse"),
                FollowedId = createFollowDto.FollowedId,
                FollowerId = createFollowDto.FollowerId,
                Time = GetTimeNow()
            };
        }

        public static Follow ToUpdateFollow(this UpdateFollowDto updateFollowDto){
            return new Follow{
                FollowedId = updateFollowDto.FollowedId,
                FollowerId = updateFollowDto.FollowerId,
                Time = GetTimeNow()
            };
        }
    }
}