using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BE.Dto.RoleUser
{
    public class RoleUserRequestDto
    {
        public string? Id {get; set;}
        public string? UserId {get; set;}
        public string? RoleId {get; set;}
        public int? Status {get; set;}
    }
}