using BE.Dto.RoleUser;
using BE.Models;
using static BE.Utils.Utils;

namespace BE.Mappers
{
    public static class RoleUserMappers
    {
        public static RoleUser ToCreateRoleUser(this CreateRoleUserDto createRoleUserDto){
            return new RoleUser{
                Id = GenerateIdModel("roleuser"),
                UserId = createRoleUserDto.UserId,
                RoleId = createRoleUserDto.RoleId
            };
        }

        public static RoleUser ToUpdateRoleUser(this UpdateRoleUserDto updateRoleUserDto){
            return new RoleUser{
                UpdateDate = GetTimeNow(),
                RoleId = updateRoleUserDto.RoleId,
                UserId = updateRoleUserDto.UserId
            };
        }
    }
}