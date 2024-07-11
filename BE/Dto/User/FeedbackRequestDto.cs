using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BE.Dto.User
{
    public class FeedbackRequestDto
    {
        public string? Id { get; set; }
        public UserRequestManagementByAdminDto UserRequest { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public bool? IsRead { get; set; }
    }
}