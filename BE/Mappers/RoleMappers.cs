using BE.Dto.Role;
using BE.Models;
using static BE.Utils.Utils;

namespace BE.Mappers
{
    public static class RoleMappers
    {
        public static Role ToCreateRole(this CreateRoleDto createRoleDto)
        {
            return new Role
            {
                Id = GenerateIdModel("role"),
                Name = createRoleDto.Name,

            };
        }

        public static Role ToUpdateRole(this UpdateRoleDto updateRoleDto)
        {
            return new Role
            {
                Name = updateRoleDto.Name,
            };
        }
    }
}