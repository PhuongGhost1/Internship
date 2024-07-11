using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BE.Dto.User
{
    public class UpdateUserDto
    {
        public string? UserId { get; set; }
        public bool? NewStatus { get; set; }
    }
}