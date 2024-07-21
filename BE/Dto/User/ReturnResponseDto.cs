using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BE.Dto.User
{
    public class ReturnResponseDto
    {
        public string? Code { get; set; }
        public string? State { get; set; }
        public string? Email { get; set; }
    }
}