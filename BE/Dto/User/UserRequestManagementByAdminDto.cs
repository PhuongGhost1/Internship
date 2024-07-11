using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BE.Dto.ImageD;
using BE.Dto.RoleUser;

namespace BE.Dto.User
{
    public class UserRequestManagementByAdminDto
    {
        public string? Id { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Description { get; set; }
        public string? Phone { get; set; }
        public DateTime? CreateAt { get; set; }
        public List<ImageForAdminDto> Images {get; set;} = new List<ImageForAdminDto>();
        public List<RoleUserRequestDto> RoleUserReqs {get; set;} = new List<RoleUserRequestDto>();
    }
}